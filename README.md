# NewtonsoftComplexJSONExample
## Create a complex JSON object using Newtonsoft Json.NET
## The code will: 
- Read the contents of a JSON file
- Create a new JObject containing the contents of the read file
- Add a new record to the JObject
- Write the new JObject's contents to a file
- Save the file to the server
## The code will return the following JSON object:
``` {"location":{"1":{"lat":"67678967","lng":"s9907897"},"2":{"lat":"67895645","lng":"0989435"},"3":{"lat":"3245","lng":"79763"},"4":{"lat":"3245","lng":"79763"}}}```

(You may notice that the Latitude and Longitude values are not real values and only provided for testing purposes)
## Details:
- The code herein is written as a .netCore application
- More specifcally the code is of type .netCore WebAPI
- CORS reference exists in code but should be deleted if CORS is not being used
- The JSON object is stored in the location.txt file referred to in the beginning of the code example
- The code was developed to store GPS coordinates
## The code herein is published on a Linux box using an Ubuntu OS within a .NetCore application built and published using dotnet CLI and served on a (Lightning Fast)Kestrel web server.
## Final thoughts:
Json.NET is powerful but not easy to work with, but MOST importantly for my requirements, it works well with .netCore. BTW, .netCore is AWESOME!




