//+#nuget Global.Sys
using System;
using System.Text;
using static Global.EasyObject;
using static Global.Sys;
try
{
    ShowDetail = true;
    //SilentFlag = true;
    string output = GetProcessStdout(
        //Encoding.UTF8,
        Encoding.GetEncoding(932),
        "dir-multi.exe", "P:/@youtube-1080p"
        );
}
catch (Exception e)
{
    Crash(e);
}
