// ----------------------------------------------------------------------------------------------
// Copyright 2015 Mårten Rånge
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------
// Start up Suave.io
// --------------------------------------------------------------------------------------

#r "FSharp.Compiler.Interactive.Settings"
#r "../packages/Suave/lib/net40/Suave.dll"
#r "../packages/M3.MiniJson/lib/net40-client/MiniJson.dll"

#load "WebPartT.fs"
#load "MyService.fs"

open Microsoft.FSharp.Compiler.Interactive

open Suave
open Suave.Http.Successful
open Suave.Web
open Suave.Types
open System.Net

let port =
  let args = Settings.fsi.CommandLineArgs
  if args.Length < 2 then uint16 8083
  else
    args.[1] |> Sockets.Port.Parse

let serverConfig =
    { defaultConfig with bindings = [ HttpBinding.mk HTTP IPAddress.Loopback port ] }

startWebServer serverConfig MyService.App
