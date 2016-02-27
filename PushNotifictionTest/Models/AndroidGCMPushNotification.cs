using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;
using PushNotifictionTest.Models;

public class AndroidGCMPushNotification
{
    public AndroidGCMPushNotification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string SendNotification(string deviceId,MyIndexModel model)
    {
        string GoogleAppID = "Api_Key";
        var request = WebRequest.Create("https://android.googleapis.com/gcm/send");
        request.Method = "post";
        request.ContentType = "application/json";
        request.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

        string postData = "{\"collapse_key\": \"score_update\"," +
                           "\"to\" : \"" + deviceId+ "\"," +
                          "\"data\": {\"message\":\""+model.Message+ "\" ,\"title\":\""+ model.Title +"\",\"person\":"+model.Person+"}}";

//            "collapse_key=score_update&time_to_live=108&delay_while_idle = 1&data.message = " 
//            + value + " &data.time = " + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";
        Console.WriteLine(postData);
        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        request.ContentLength = byteArray.Length;

        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        WebResponse tResponse = request.GetResponse();

        dataStream = tResponse.GetResponseStream();

        StreamReader tReader = new StreamReader(dataStream);

        String sResponseFromServer = tReader.ReadToEnd();

        tReader.Close();
        dataStream.Close();
        tResponse.Close();
        return sResponseFromServer;
    }
}