<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VideoStore.WebClient.ViewModels.CatalogueViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListMedia
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ListMedia</h2>

    <table>
        <tr>
            <th></th>
        </tr>

    <% foreach (var item in Model.MediaListPage) { %>
    
        <tr>
            <td>
                <%: item.pMedia.Title %>
                Price: $<%: item.pMedia.Price %>

                <span>
                <% using(Html.BeginForm("AddToCart", "Cart")) { %>
                    <%= Html.Hidden("pMediaId", item.pMedia.Id) %>
                    <%= Html.Hidden("pReturnUrl", ViewContext.HttpContext.Request.Url.PathAndQuery) %>
                    
                    <input type="submit" value="+ Add to Cart" />
                <%} %>
                </span>
                
            </td>
            <td>
            <style>
                    .like
                    {
                        float:right;   
                     }
                </style>
                <%-- when the media is not in the user's like list, render the 'Like' button
                    else: render just text 'Liked'
                   --%>
                <%if (!item.Liked)
                  { %>
                    <span class="like"><% using (Html.BeginForm("Like", "Recommendation"))
                             { %>
                        <%= Html.Hidden("pMediaId", item.pMedia.Id)%>
                        <%= Html.Hidden("pReturnUrl", Url.Action("ListMedia", "Store"))%>
                        <input type="submit" value="Like" />
                        <%} %>
                    </span>
                   <% }
                  else
                  { %>
                  <span class="like">Liked</span>
                   <% } %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

