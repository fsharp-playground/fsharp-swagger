

namespace FSharpSwagger

open System.Collections.Generic
open System.Web.Http

type ValueController() =
    inherit ApiController()

    [<HttpGet>]
    member this.Get() =
        "Hello, world!"
