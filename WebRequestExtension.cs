﻿// Decompiled with JetBrains decompiler
// Type: SamFirm.WebRequestExtension
// Assembly: SamFirm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 14A8B9D4-ACD6-4CE0-9F53-A466F0519E6A
// Assembly location: C:\Users\Ivan\Desktop\LG Flash Tool 2014\SamFirm\SamFirm.exe

using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SamFirm
{
  public static class WebRequestExtension
  {
    public static WebResponse GetResponseFUS(this WebRequest wr)
    {
      try
      {
        WebResponse response = wr.GetResponse();
        if (((IEnumerable<string>) response.Headers.AllKeys).Contains<string>("Set-Cookie"))
          Web.JSessionID = response.Headers["Set-Cookie"].Replace("JSESSIONID=", "").Split(';')[0];
        if (((IEnumerable<string>) response.Headers.AllKeys).Contains<string>("NONCE"))
          Web.Nonce = response.Headers["NONCE"];
        return response;
      }
      catch (WebException ex)
      {
        Logger.WriteLog("Error getting response: " + ex.Message, false);
        if (ex.Status == WebExceptionStatus.NameResolutionFailure)
          Web.SetReconnect();
        return ex.Response;
      }
    }
  }
}
