<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Your Recommendations
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Recommendations:</h2>

    <%= (string)Model.test %>
    <%
    foreach (var Recommendation in Model.RecommendationListPage)
       { %>
       <%= Recommendation.Medium.Title %><br />
       <%= Recommendation.Medium.Director %><br />
    <% }%>
    

</asp:Content>