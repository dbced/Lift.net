Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml

Public Class wsVisiRun
    Public Shared Function visrun_getCurrentPosition(targa As String) As String
        Try

            Dim _url = My.Settings.urlWSVisirun

            Dim _action = ""
            Dim soapEnvelopeXml As XmlDocument = CreateSoapEnvelope_getCurrentPosition(targa)
            Dim webRequest As HttpWebRequest = CreateWebRequest(_url, _action)
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest)
            Dim asyncResult As IAsyncResult = webRequest.BeginGetResponse(Nothing, Nothing)
            asyncResult.AsyncWaitHandle.WaitOne()
            Dim soapResult As String

            Using webResponse As WebResponse = webRequest.EndGetResponse(asyncResult)
                Using rd As StreamReader = New StreamReader(webResponse.GetResponseStream())
                    soapResult = rd.ReadToEnd()
                End Using
                Return soapResult
            End Using

        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Shared Function visrun_getNearestVehicles(lat As String, lng As String, Optional radius As String = "2000", Optional targa As String = "") As String
        Try

            Dim soapResult As String = ProcessRequest(lat, lng, radius, targa)
            Return soapResult

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Shared Function ProcessRequest(lat As String, lng As String, radius As String, Optional targa As String = "") As String
        Dim soapResult As String = String.Empty

        Try
            Dim sXml As String = "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:Tracking"">"
            sXml = sXml & "<soapenv:Header/>" & vbCrLf
            sXml = sXml & "<soapenv:Body>" & vbCrLf
            sXml = sXml & "<urn:getNearestVehicles soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & vbCrLf
            sXml = sXml & "<key xsi:type=""xsd:string"">c6d89eb6248838efdbfd7dbcfdd264e6</key>" & vbCrLf
            sXml = sXml & "<vehicleCode xsi:type=""xsd:String"">" & targa & "</vehicleCode>" & vbCrLf
            sXml = sXml & "<latitude xsi:type="" xsd:string"">" & lat.Replace(",", ".") & "</latitude>" & vbCrLf
            sXml = sXml & "<longitude xsi:type=""xsd:string"">" & lng.Replace(",", ".") & "</longitude>" & vbCrLf
            sXml = sXml & "<address xsi:type=""xsd:String""></address>" & vbCrLf
            sXml = sXml & "<radius xsi:type=""xsd:string"">" & radius & "</radius>" & vbCrLf
            sXml = sXml & "</urn:getNearestVehicles>" & vbCrLf
            sXml = sXml & "</soapenv:Body>" & vbCrLf
            sXml = sXml & "</soapenv:Envelope>"

            Dim data As String = sXml
            Dim url As String = "http://www.visirun.com/public/Server.php"
            Dim responsestring As String = ""

            Dim myReq As HttpWebRequest = WebRequest.Create(url)
            Dim proxy As IWebProxy = CType(myReq.Proxy, IWebProxy)
            Dim proxyaddress As String
            Dim myProxy As New WebProxy()
            Dim encoding As New ASCIIEncoding
            Dim buffer() As Byte = encoding.GetBytes(sXml)
            Dim response As String

            myReq.AllowWriteStreamBuffering = False
            myReq.Method = "POST"
            myReq.ContentType = "text/xml; charset=UTF-8"
            myReq.ContentLength = buffer.Length
            'myReq.Headers.Add("SOAPAction", "http://tempuri.org/SaveIncomingFile")
            'myReq.Credentials = New NetworkCredential("abc", "123")
            'myReq.PreAuthenticate = True
            'proxyaddress = proxy.GetProxy(myReq.RequestUri).ToString

            'Dim newUri As New Uri(proxyaddress)
            'myProxy.Address = newUri
            'myReq.Proxy = myProxy
            Dim post As Stream = myReq.GetRequestStream

            post.Write(buffer, 0, buffer.Length)
            post.Close()

            Dim myResponse As HttpWebResponse = myReq.GetResponse
            Dim responsedata As Stream = myResponse.GetResponseStream
            Dim responsereader As New StreamReader(responsedata)

            soapResult = responsereader.ReadToEnd

        Catch __unusedException1__ As Exception
            Throw
        End Try

        Return soapResult

    End Function

    Private Shared Function CreateWebRequest(ByVal url As String, ByVal action As String) As HttpWebRequest

        Dim webRequest As HttpWebRequest = CType(webRequest.Create(url), HttpWebRequest)
        Try
            'webRequest.Headers.Add("SOAPAction", action)
            webRequest.ContentType = "text/xml;charset=""utf-8"""
            'webRequest.Accept = "text/xml"
            webRequest.Method = "POST"
            Return webRequest

        Catch ex As Exception
            Return webRequest
        End Try
    End Function


    Private Shared Function CreateSoapEnvelope_getCurrentPosition(targa As String) As XmlDocument
        Try
            Dim soapEnvelopeDocument As XmlDocument = New XmlDocument()
            soapEnvelopeDocument.LoadXml("<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:Tracking"">
                                         <soapenv:Header/>
                                         <soapenv:Body>
                                             <urn:getCurrentPosition soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                                                 <key xsi:type=""xsd:string"">c6d89eb6248838efdbfd7dbcfdd264e6</key>
                                                 <vehicleCode xsi:type=""xsd:string"">" & targa & "</vehicleCode>
                                             </urn:getCurrentPosition>
                                         </soapenv:Body>
                                     </soapenv:Envelope>")
            Return soapEnvelopeDocument
        Catch ex As Exception

        End Try
    End Function


    Private Shared Sub InsertSoapEnvelopeIntoWebRequest(ByVal soapEnvelopeXml As XmlDocument, ByVal webRequest As HttpWebRequest)
        Try
            Using stream As Stream = webRequest.GetRequestStream()
                soapEnvelopeXml.Save(stream)
            End Using
        Catch ex As Exception

        End Try
    End Sub




End Class
