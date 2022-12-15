# ButterCMS ASP.NET MVC Example

This app uses Razor templates but ButterCMS works with any templating engine like DotLiquid or Handlebars.NET.

## Important Notice
This project was created as an example use case of ButterCMS in conjunction with the .NET framework and will not be actively maintained. 

If you’re interested in exploring the best, most up-to-date way to integrate Butter into .NET projects, you can check out the following resources:

### Starter Projects

The following turn-key starters are fully integrated with dynamic sample content from your ButterCMS account, including main menu, pages, blog posts, categories, and tags, all with a beautiful, custom theme with already-implemented search functionality. All of the included sample content is automatically created in your account dashboard when you sign up for a free trial of ButterCMS.
- [.NET Starter](https://buttercms.com/starters/dotnet-starter-project/)
- [Angular Starter](https://buttercms.com/starters/angular-starter-project/)
- [React Starter](https://buttercms.com/starters/react-starter-project/)
- [Vue.js Starter](https://buttercms.com/starters/vuejs-starter-project/)
- Or see a list of all our [currently-maintained starters](https://buttercms.com/starters/). (Over a dozen and counting!)

### Other Resources
- Check out the [official ButterCMS Docs](https://buttercms.com/docs/)
- Check out the [official ButterCMS API docs](https://buttercms.com/docs/api/)


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

### Other

View .NET [Blog engine](https://buttercms.com/asp-net-blog-engine/) and [Full CMS](https://buttercms.com/asp-net-cms/) for other examples of using ButterCMS with .NET.
