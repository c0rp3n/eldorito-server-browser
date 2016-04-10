# TempName

To edit the config open **TempName.exe.config** in a text editor and you'll be greated with a number of lines of text, the things to look for are:

\<setting name="**IsUsingName**" serializeAs="String">\<value>**False**\</value>

This value is either **True** if you want to see the servers that contain ServerNameContainsThis in them or **False** if you, the default value is **False**.


\<setting name="**IsUsingLog**" serializeAs="String">\<value>**False**\</value>

This value is either **True** or **False**, the default value is **False**.


\<setting name="**RefreshRate**" serializeAs="String">\<value>**10**\</value>

This value is a number and is for the sleep method, the default value is **10**.


\<setting name="**ServerNameContainsThis**" serializeAs="String">\<value>**G-Money**\</value>

This value is a string and is for searching for servers that contain this value, the default value is **G-Money** as he was the one that I made this thing for.


\<setting name="**LogFilePathAndName**" serializeAs="String">\<value>**Log.txt**\</value>

This value is a string and is for the name of the log file, the log file can only be in the current working directory that has TempName.exe in, the default value is **Log.txt**.


\<setting name="**PlayerName**" serializeAs="String">\<value>**PlayerName**\</value>

This value is a string and is for searching for player names that contain this value, You will see **"IsSpecified UID: PlayerUID Name: PlayerName"** if a player with that name is on a server, the default value is **PlayerName** and the longest it can be is 16 characters long.


\<setting name="**PlayerUID**" serializeAs="String">\<value>**1234567887654321**\</value>

This value is a string and is for searching for player uids that contain this value, You will see **"IsSpecified UID: PlayerUID Name: PlayerName"** if a player with that uid is on a server, the default value is **1234567887654321** and the longest it can be is 16 characters long.

