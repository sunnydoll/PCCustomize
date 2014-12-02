Zhichao Cao<br />
Email: zc77@drexel.edu<br />
Project: Discussion Forum for Customized PC<br />
(This is an individual project)<br />
<br />
The idea and goal of the project:<br />
This project is trying to build a small discussion forum similar to the Discussion Board of BBLearn but focusing on the topic of customized computer input by user. More and more young guys including me like to buy the computer which is customized by themselves rather than buying an entire one which has been setup by a computer factory. In the discussion forum, users can post topics and replies associating the topics focusing on the customized computer posted by one of the users.<br />
I used to work with traditional ASP.Net Webform to build web application and the experience of using advanced technology and framework on building modern web application is very limited. So this is a very good opportunity to learn these new stuff by myself and to cover these new in my project.<br />
<br />
If you want to build my project:<br />
There are some environment tools required to setup as follows:<br />
1..Net Framework 3.5, this is the necessary library for almost all Microsoft products,<br />
2.IIS 8.0 Express (Windows Vista or up), or IIS 7.5 (Windows XP), it is an express version server for running my application,<br />
3.Microsoft SQL Express LocalDB Edition 11.0, it is an express version data base for storing my data file,<br />
4.Windows Azure Tools, management tool for ASP.Net web applications,<br />
5.Visual Studio Express 2012, since I used the server of express version rather an independent one and all my files are source code, installing Visual Studio Express 2012 which is free to setup all my files is a good choice, you are able to build and run my project easily with it.<br />
All things listed above are easily to download and install by a product provided by Microsoft which is Web Platform Installer.<br />
<br />
After you setup all required tools,<br />
1.You need find out my database files which are stored under PCCustomize\PCCustomize\App_Data folder, attach these files in your SQL Server,<br />
2.You need find the Web.config file under PCCustomize\PCCustomize\ folder, find and modify the content between the pair of tag "connectionStrings" to your environment.<br />
3.Open the file PCCustomize.sln under PCCustomize\PCCustomize\ folder by your Visual Studio Express 2012 and press Ctrl+F5 to run the project. Then you can open this web application in your default browser.<br />
