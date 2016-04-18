

namespace FSharpSwagger

open System.Collections.Generic
open System.Web.Http
open Swashbuckle.SwaggerUi
open Swashbuckle.Swagger.Annotations

type ValueController() =
    inherit ApiController()

    [<SwaggerOperation("get")>]
    [<HttpGet>]
    member this.Get() =
        "Hello, world!"
