# .NET client Library for encoding Videos with Coconut

## Submitting the job

Use the [API Request Builder](https://app.coconut.co/job/new) to generate a config file that match your specific workflow.

Example of `coconut.conf`:

```ini
var s3 = s3://accesskey:secretkey@mybucket

set source = http://yoursite.com/media/video.mp4
set webhook = http://mysite.com/webhook/coconut

-> mp4  = $s3/videos/video.mp4
-> webm = $s3/videos/video.webm
-> jpg_300x = $s3/previews/thumbs_#num#.jpg, number=3
```

Here is the C# code to submit the config file:

```csharp
using System;
using System.Collections.Generic;
using Coconut;

namespace Sample
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      string Config = System.IO.File.ReadAllText(@"coconut.conf");
      CoconutAPI Coconut = new CoconutAPI ("api-key");

      CoconutJob Job = Coconut.Submit (Config);
      Console.WriteLine (Job.Id);
    }
  }
}
```

*Released under the [MIT license](http://www.opensource.org/licenses/mit-license.php).*

---

* Coconut website: http://coconut.co
* API documentation: http://coconut.co/docs
* Contact: [support@coconut.co](mailto:support@coconut.co)
* Twitter: [@OpenCoconut](http://twitter.com/opencoconut)