@model IEnumerable<TheatreCMS3.Areas.Blog.Models.Comment>
@using TheatreCMS3.Helpers
@{
  ViewBag.Title = "_Comments";
}
<!--This is the table that lists comments stored in the database. It is in this partial view so other parts of the program can easily access this chunk of information more easily.-->
@foreach (var item in Model)
{
  <div class="comment">
    <div class="media">
      <div class="media-body">

        <div class="commentUserName">
          @Html.DisplayFor(modelItem => item.Author)<!--Author name would go here-->
        </div>
        <br />
        <p>
          <button type="button"><i class="fas fa-angle-double-up"></i></button><!--buttons for the likes and dislikes next to the number of each-->
          @item.Likes-Like(s)
          <button type="button"><i class="fas fa-angle-double-down"></i></button>
          @item.Dislikes-Dislike(s)
        </p>
      </div>
      <div class="media mt-3">
        <div>
          @item.LikeRatio<!--percentage liked is listed here-->
          % Percent Liked
        </div>
        <p>
          <br />
          Posted @TextHelpers.TimeAgo(item.CommentDate)<!--date and time since this comment was created is posted here-->
        </p>
      </div>
    </div>
    <div class="media mt-3">
      <p>
        @Html.DisplayFor(modelItem => item.Message)<!--the content of the comment message-->
      </p>
    </div>
    <div class="media mt-3">
      <button type="button">Reply</button>
    </div>
    <div>
      <button type="button"><i class="fa fa-trash" aria-hidden="true"></i></button><!--trash can image on a button via font-awesome-->
    </div>
    <br />
    <hr class="mt-3 mb-3" />
  </div>