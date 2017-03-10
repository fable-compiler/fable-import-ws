namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Node

module Ws =
    type [<AllowNullLiteral>] [<Import("*","WebSocket")>] WebSocket =
        inherit NodeJS.EventEmitter
        abstract CONNECTING: int with get
        abstract OPEN: int with get
        abstract CLOSING: int with get
        abstract CLOSED: int with get
        abstract bytesReceived: int with get
        abstract readyState: int with get
        abstract protocolVersion: string with get
        abstract url: string with get
        abstract supports: obj with get
        abstract upgradeReq: http_types.IncomingMessage with get
        abstract protocol: string with get
        abstract onopen: obj -> unit
        abstract onerror: Error -> Unit
        abstract onclose: obj -> unit
        abstract onmessage: obj -> unit
        abstract close: ?code: float * ?data: obj -> unit
        abstract pause: unit -> unit
        abstract resume: unit -> unit
        abstract ping: ?data: obj * ?options: obj * ?dontFail: bool -> unit
        abstract pong: ?data: obj * ?options: obj * ?dontFail: bool -> unit
        abstract send: data: obj * ?cb: (Error -> unit) -> unit
        abstract send: data: obj * options: obj * ?cb: (Error -> unit) -> unit
        abstract stream: options: obj * ?cb: (Error -> bool -> unit) -> unit
        abstract stream: ?cb:  (Error -> bool -> unit) -> unit
        abstract terminate: unit -> unit
        [<Emit("$0.addEventListener('message',$1...)")>] abstract addEventListener_message: cb: (obj -> unit) -> unit
        [<Emit("$0.addEventListener('close',$1...)")>] abstract addEventListener_close: cb: (obj -> unit) -> unit
        [<Emit("$0.addEventListener('error',$1...)")>] abstract addEventListener_error: cb: (Error -> unit) -> unit
        [<Emit("$0.addEventListener('open',$1...)")>] abstract addEventListener_open: cb: (obj -> unit) -> unit
        abstract addEventListener: ``event``: string -> listener: (obj -> unit) -> unit
        [<Emit("$0.on('error',$1...)")>] abstract on_error: cb: (Error -> unit) -> unit
        [<Emit("$0.on('close',$1...)")>] abstract on_close: cb: (obj -> unit) -> unit
        [<Emit("$0.on('message',$1...)")>] abstract on_message: cb: (obj -> unit) -> unit
        [<Emit("$0.on('ping',$1...)")>] abstract on_ping: cb: (obj -> bool -> bool -> unit) -> unit
        [<Emit("$0.on('pong',$1...)")>] abstract on_pong: cb: (obj -> bool -> bool -> unit) -> unit
        [<Emit("$0.on('open',$1...)")>] abstract on_open: cb: (obj -> unit) -> unit
        abstract on: ``event``: string * listener: (obj -> unit) -> unit

    and VerifyClientCallbackSync = Func<obj, bool>

    and VerifyClientCallbackAsync = Func<obj, Func<bool, unit>, unit>

    and IClientOptions = interface end

    and IPerMessageDeflateOptions = interface end

    and IServerOptions = interface end

    and [<AllowNullLiteral>] [<Import("Server","WebSocket")>] Server =
        inherit NodeJS.EventEmitter
        abstract options: IServerOptions with get,set 
        abstract path: string with get,set 
        abstract clients: ResizeArray<WebSocket> with get,set
        abstract close: callback:obj -> unit 
        abstract handleUpgrade: request: http_types.IncomingMessage * socket: net_types.Socket * upgradeHead: Buffer * callback: (WebSocket -> unit) -> unit
        [<Emit("$0.on('error',$1...)")>] abstract on_error: (Error -> unit) -> unit
        [<Emit("$0.on('headers',$1...)")>] abstract on_headers: (ResizeArray<string> -> unit) -> unit
        [<Emit("$0.on('connection',$1...)")>] abstract on_connection: (WebSocket -> unit) -> unit
        abstract on: ``event``: string * listener: (obj -> unit) -> unit

    and Globals =
        [<Emit("new $0.Server($1)")>]
        abstract createServer: options: IServerOptions list -> Server
        [<Emit("new $0.Server($1...)")>]
        abstract createServer: options: IServerOptions list * ?connectionListener: (WebSocket -> unit) -> Server


