namespace FSharpSwagger

open Owin
open Microsoft.Owin
open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Http.Owin
open Microsoft.Owin.Diagnostics.Views
open Microsoft.Owin.Hosting
open Swashbuckle.Application

type Params = {
    Id: RouteParameter
}

[<Sealed>]
type Startup() =

    static member RegisterWebApi(config: HttpConfiguration) =
        // Configure routing
        config.MapHttpAttributeRoutes()
        config.EnableSwagger().EnableSwaggerUi()

        // Configure serialization
        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        config.Routes.MapHttpRoute(
                                        name = "DefaultApi",
                                        defaults = { Id = RouteParameter.Optional } ,
                                        routeTemplate = "api/{controller}/{action}/{id}" ) |> ignore


        // Additional Web API settings

    member __.Configuration(builder: IAppBuilder) =
        let config = new HttpConfiguration()
        Startup.RegisterWebApi(config)
        builder.UseWebApi(config) |> ignore
        builder.UseErrorPage() |> ignore
        builder.UseWelcomePage() |> ignore


module Program =

    [<EntryPoint>]
    let main argv =
            let baseAddress = "http://localhost:9000"

            printf "|| start | %s\n" baseAddress

            use app = WebApp.Start<Startup>(url = baseAddress)
            Console.ReadLine() |> ignore
            0
