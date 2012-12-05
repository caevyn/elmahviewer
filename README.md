elmahviewer
===========

A central viewer for elmah

This is a viewer for ELMAH. It reuses and modifies some code from the ELMAH project i.e. it is a derivative work.
This is built to fit a specific use case where many apps share a common sql error log and you want an internal web app to view it.
If you want to view the logs without being on the server and without having to secure the handler in every app this might be useful, otherwise not.

This has been knocked up pretty quickly and has no tests.
Just set your connection string in the web config.


http://code.google.com/p/elmah/


//
// ELMAH - Error Logging Modules and Handlers for ASP.NET
// Copyright (c) 2004-9 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
