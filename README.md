# Hosts Switcher
This small tray icon utility takes care about your host files, so developer can easily switch between QA, production and local environment.

Web developers in big companies (such as myself) often struggles with different environments - local, QA, production, performance test environment, etc. To make things more difficult, we're usually taking care about multiple web sites. This simple tool helps you out to change hosts quickly - by overwriting your C:\Windows\System32\drivers\etc\hosts file (which is serving as first level dns proxy) by set of predefined hosts.

Please note web browsers have dns cache on their own so once you change hosts; you have to either close and reopen your browser once you do the change or use some plugin - such as DNS flusher in Mozilla.

![Hosts Switcher Screenshot](/hosts-switcher.png)
