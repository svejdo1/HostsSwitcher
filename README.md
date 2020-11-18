# Hosts Switcher
This small tray icon utility takes care about your host files, so developer can easily switch between QA, production and local environment.

Web developers in big companies (such as myself) often struggles with different environments - local, QA, production, performance test environment, etc. To make things more difficult, we're usually taking care about multiple web sites. This simple tool helps you out to change hosts quickly - by overwriting your C:\Windows\System32\drivers\etc\hosts file (which is serving as first level dns proxy) by set of predefined hosts.

This version operates by creating and saving different host profiles which can be rapidly written to the windows hosts file. This prevents having multiple hosts files in the directory at a time and allows for easy manipulation of which sites are blocked (or rerouted). The XML document specifies a few parameters for each address: 
  Enabled: Identifies if the line is to be used at all
  Local: Will use localhost instead of any specified Redirection
  Www: Will add both the original domain and www.originaldomain so that neither can be accessed
  Redirected: the IP address that the domain will be directed to
  Address: The domain that will be redirected
  
This xml file is saved to your application data folder and can be Exported or Imported using the Export/Import profiles under the File menu.

Please note web browsers have dns cache on their own so once you change hosts; you have to either close and reopen your browser once you do the change or use some plugin - such as DNS flusher in Mozilla.

![Hosts Switcher Screenshot](/hosts-switcher.png)

Using the Import Hosts tool (+++ icon in lower right) You can copy and paste in domains to be added, or whole hosts files for rapid entry

![Hosts Import Tool](/ImportHosts-Example.png)
