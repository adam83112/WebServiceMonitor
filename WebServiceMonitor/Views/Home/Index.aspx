<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
	<title></title>
</head>
<body>
	<h2>Web Service Monitor</h2>
	<table>
    	<tr>
            <th>Name</th>
            <th>Status</th>
        </tr> 
		<% foreach (var item in ViewData["WebServices"] as IEnumerable<WebServiceMonitor.WebService>)%>
		<% { %>
			<tr>
            	<td>
            		<a href="<% Response.Write(item.Url); %>"><% Response.Write(item.Name); %></a>
            	</td>
            	<td> 
            		<font color="<% Response.Write(item.IsOk ? "green" : "red"); %>"><% Response.Write(item.Status.ToString()); %></font> 
            	</td>
        	</tr>
		<% } %>
	 </table>
</body>


