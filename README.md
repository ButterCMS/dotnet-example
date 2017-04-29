# ButterCMS ASP.NET MVC Example

This app uses Razor templates but ButterCMS works with any templating engine like DotLiquid or Handlebars.NET.

## Get Started

Open ButterCmsExample.sln in Visual Studio 2015 or higher, then run it with `Debug` -> `Start Debugging` or by pressing `F5`.

## Features

This example application demonstrates three major features of the ButterCMS API &mdash; blogging, dynamic content, and dynamic pages. All of the features are implemented in the following files:

 - `Controllers/BlogController.cs`: The application controller and routing.
 - `Views/Blog/*.cshtml`: The MVC/Razor templates used for rendering the content.

### Blogging

The blogging features are split into four main areas withing the app &mdash; posts, categories, tags, and authors. Each area has a main page and a detail page.

- #### Posts
  Blog posts are loaded in the `ListAllPosts()` and `ShowPost()` methods of the `BlogController` and rendered to the `Posts.cshtml` and `Post.cshtml` templates.
- #### Categories
  Post categories are loaded in the `ListAllCategories()` and `ShowCategory()` methods and rendered to the `Categories.cshtml` and `Category.cshtml` templates.
- #### Tags
  Post tags are loaded in the `ListAllTags()` and `ShowTag()` methods and rendered to the `Tags.cshtml` and `Tag.cshtml` templates.
- #### Authors
  Post authors are loaded in the `ListAllAuthors()` and `ShowAuthor()` methodsd and rendered to the `Authors.cshtml` and `Author.cshtml` templates.

### Dynamic Content

Dynamic content is demonstrated with a Frequenly Asked Question page. FAQ questions and answers, as well as the page headline, are loaded in the `ShowFaq()` method of the `BlogController` and rendered to the `Faq.cshtml` template.

### Dynamic Pages

Dynamic pages are demonstrated with mock store location pages. Location page data is loaded by the `ListAllLocations()` and `ShowLocation()` method of the `BlogController` and rendered to the `Locations.cshtml` and `Location.cshtml` templates.

## Documentation

For a comprehensive list of examples and API docs, check out our [documentation](https://buttercms.com/docs/).