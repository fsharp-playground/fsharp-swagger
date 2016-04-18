

namespace FSharpSwagger

open System.Collections.Generic
open System.Web.Http
open Swashbuckle.SwaggerUi

type Value =
    { Key: string
      Value: string }

type ValueController() =
    inherit ApiController()

    [<HttpPost>]
    member this.DeleteValue(value: Value) =
        value

    [<HttpPost>]
    member this.UpdateValue(value: Value) =
        value

    [<HttpGet>]
    member this.SayHello() =
        "Hello, world!"
