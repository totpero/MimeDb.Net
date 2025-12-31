# MimeDb.Net

[![NuGet](https://img.shields.io/nuget/v/MimeDb.Net.svg?style=flat-square)](https://www.nuget.org/packages/MimeDb.Net/1.54.0)

This is a port of the popular JavaScript [mime-db](https://github.com/jshttp/mime-db) library to C#


[mime-db](https://github.com/jshttp/mime-db) is a large database of mime types and information about them.
It consists of a single, public JSON file and does not include any logic,
allowing it to remain as un-opinionated as possible with an API.
It aggregates data from the following sources:

- https://www.iana.org/assignments/media-types/media-types.xhtml
- https://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types
- https://hg.nginx.org/nginx/raw-file/default/conf/mime.types

## Install the package:

```powershell
dotnet add package MimeDb.Net
```

## Usage

```csharp
// grab data on .js files
var data = MimeDb.Items['application/javascript']
```
## Data Structure

The JSON file is a map lookup for lowercased mime types.
Each mime type has the following properties:

- `.source` - where the mime type is defined.
    If not set, it's probably a custom media type.
    - `apache` - [Apache common media types](https://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types)
    - `iana` - [IANA-defined media types](https://www.iana.org/assignments/media-types/media-types.xhtml)
    - `nginx` - [nginx media types](https://hg.nginx.org/nginx/raw-file/default/conf/mime.types)
- `.extensions[]` - known extensions associated with this mime type.
- `.compressible` - whether a file of this type can be gzipped.
- `.charset` - the default charset associated with this type, if any.


## Contributing

The primary way to contribute to this database is by creating pull request to
the original repo [mime-db](https://github.com/jshttp/mime-db). 
See the contribution rules.
