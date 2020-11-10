using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Barbar.HostsSwitcher
{
    public struct Domain
    {
        public bool isEnabled;
        public bool alsoWWW;
        public bool useLocalhost;
        public Domain(string redirectedAddress, string domainToRedirect)
        {
            this.domainToRedirect = domainToRedirect;
            this.redirectedAddress = redirectedAddress;
            this.isEnabled = false;
            this.alsoWWW = true;
            this.useLocalhost = true;
        }
        public string domainToRedirect;
        public string redirectedAddress;
        
    }
    public class HostsProfile
    {
        private static string header = "# Copyright (c) 1993-2009 Microsoft Corp.\n#\n#\n# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.\n#\n# This file contains the mappings of IP addresses to host names. Each\n# entry should be kept on an individual line. The IP address should\n# be placed in the first column followed by the corresponding host name.\n# The IP address and the host name should be separated by at least one\n# space.\n#\n# Additionally, comments (such as these) may be inserted on individual\n# lines or following the machine name denoted by a '#' symbol.\n#\n# For example:\n#\n#      102.54.94.97     rhino.acme.com          # source server\n#       38.25.63.10     x.acme.com              # x client host\n\n# localhost name resolution is handled within DNS itself.\n#	127.0.0.1       localhost\n#	::1             localhost\n";
        public string profileName;
        public bool isCurrent = false;
        public List<Domain> domains=new List<Domain>();
        
       

        public HostsProfile()
        {
            this.profileName = "Default";
            this.domains = new List<Domain>();
            isCurrent = true;
        }
        public HostsProfile(string name)
        {
            if (name != "Default")
                this.profileName = name;
            else
                this.profileName = "DefaultClone";
            this.domains = new List<Domain>();
        }

        public HostsProfile(XmlElement profileXML)
        {
            this.profileName = getStringFromAttribute(profileXML, "ProfileName");
            this.isCurrent= getBoolFromAttribute(profileXML, "isCurrent");
            this.domains = new List<Domain>();
            foreach (XmlNode node in profileXML.ChildNodes)
            {
                
                switch (node.Name)
                {
                    case "Domain":
                        string url= getStringFromAttribute(node, "URL");
                        string redir = getStringFromAttribute(node, "Redirect");
                        Domain d = new Domain(redir, url);
                        d.isEnabled = getBoolFromAttribute(node, "Enabled");
                        domains.Add(d);
                        break;
                }

            }
        }

        public XmlElement toXML(XmlDocument doc)
        {
            XmlElement hostsProfile = doc.CreateElement(string.Empty, "HostsProfile", string.Empty);
            hostsProfile.SetAttribute("ProfileName", this.profileName);
            hostsProfile.SetAttribute("isCurrent", this.isCurrent.ToString());
            for (int i=0;i<domains.Count;i++)
            {
                XmlElement domain = doc.CreateElement(string.Empty, "Domain", string.Empty);
                domain.SetAttribute("URL", domains[i].domainToRedirect);
                domain.SetAttribute("Redirect", domains[i].redirectedAddress);
                domain.SetAttribute("Enabled", domains[i].isEnabled.ToString());
                hostsProfile.AppendChild(domain);
            }
            return  hostsProfile;
        }


        public string toHosts()
        {
            string output= header+"\n#Output By HostsSwitcher: Profile: "+this.profileName+"\n";
            string redir;
            foreach (Domain d in domains)
            {
                
                if (d.useLocalhost)
                    redir = "127.0.0.1";
                else
                    redir = d.redirectedAddress;

                if (d.isEnabled)
                {
                    
                    output += redir + "\t" + d.domainToRedirect + "\n";
                    if(d.alsoWWW)
                        output += redir + "\twww." + d.domainToRedirect + "\n";
                }
              
            }
            return output;
        }


        public static bool getBoolFromAttribute(XmlNode node, String attribute, bool ifNull = false)
        {
            bool d = ifNull;
            if (node == null)
                return d;
            XmlAttribute att = node.Attributes[attribute];
            if (att != null)
                bool.TryParse(att.InnerText, out d);
            return d;
        }

        public static string getStringFromAttribute(XmlNode node, String attribute, String ifNull = "")
        {
            string output = ifNull;
            if (node == null)
                return output;
            XmlAttribute att = node.Attributes[attribute];
            if (att != null)
                output = att.InnerText;
            return output;
        }

        public static string getSettingsFilepath()
        {
            string appSettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appSettingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\HostsSwitcherProfiles.xml";

            return appSettingsFilePath;
        }

        public static bool writeToSettingsXML(List<HostsProfile> myprofiles)
        {
            

            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement profilesXMLnode = doc.CreateElement(string.Empty, "HostsProfiles", string.Empty);

            bool hasCurrent = false;

            foreach(HostsProfile hp in myprofiles)
            {
                if (hasCurrent)
                    hp.isCurrent = false;

                profilesXMLnode.AppendChild(hp.toXML(doc));

                if (hp.isCurrent)
                    hasCurrent = true;
            }

            doc.AppendChild(profilesXMLnode);
            doc.Save(getSettingsFilepath());

            return true;
        }

        public static HostsProfile getCurrentProfile(List<HostsProfile> myprofiles)
        {
            foreach (HostsProfile hp in myprofiles)
            {
                if(hp.isCurrent)
                {
                    return hp;
                }
            }

            return new HostsProfile();
        }

        public static List<HostsProfile> readFromXML(string file)
        {

            List<HostsProfile> myProfiles = new List<HostsProfile>();
            bool failed = false;
            if (File.Exists(getSettingsFilepath()))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(getSettingsFilepath());

                XmlNode root = doc.DocumentElement.FirstChild;

                if (root == null) //XML file doestn' contain maze
                {
                    failed = true;
                }
                else
                {

                    XmlNode fileVersionNode = root.Attributes["version"];
                    string fileVersion = "unknown";
                    if (fileVersionNode != null)
                        fileVersion = fileVersionNode.InnerText;

                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        switch(node.Name)
                        { 
                            case "HostsProfile":
                                HostsProfile profile = new HostsProfile((XmlElement)node);
                                myProfiles.Add(profile);
                            break;
                        }
                    }
                }

            }
            else
                failed = true;

            if(failed)
            {
                HostsProfile currentHost = new HostsProfile();
                currentHost.isCurrent = true;
                myProfiles.Add(currentHost);
            }
            
            return myProfiles;
        }
    }

}
