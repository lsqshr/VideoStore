<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VideoStore.WebClient.ViewModels.RecommendationViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Your Recommendations
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <h2>
    <% if (Model.RecommendationListPage.Count() == 0)
       {%> Sorry, there have not been any recommendations generated for you yet. What about liking more items?
    <% }
       else
       { %>
        Your Recommendations:
    <% } %>    
    
    </h2>

    <%
    foreach (var Recommendation in Model.RecommendationListPage)
       { %>
       <div class="recommendation">
           <div class="title"><%= Recommendation.MostLikeMatching.Medium.Title %></div>
           <div class="director">by <%= Recommendation.MostLikeMatching.Medium.Director%></div>
           <div>price: $<%= Recommendation.MostLikeMatching.Medium.Price%></div>
           <div class="add_to_cart"><% using(Html.BeginForm("AddToCart", "Cart")) { %>
                <%= Html.Hidden("pMediaId", Recommendation.MostLikeMatching.Medium.Id)%>
                <%= Html.Hidden("pReturnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
                <input type="submit" value="+ Add to Cart" />
           </div>
           <div class="based_on">
                Based on your like of <%= Recommendation.Medium.Title %>, 
                by <%= Recommendation.Medium.Director %>
           </div>

       </div>
       <%} %>

    <% }%>
    

</asp:Content>