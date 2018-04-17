# MobiusX
Query library for Varian's Mobius software (Mobius Medical). Can be used in the automation process of evaluating Mobius calculations

## Example

```cs
 //Simple interface into web client
 var client = new MobiusContext("192.168.1.1", "physxrobot", "physxrobot");
 var patients = client.GetPatientList(500);
 foreach (var pat in pats)
 {
      foreach (var plan in pat.Plans.Where(p => p.Status != "processing")
      {
	
	 //Get detailed plan info
         var details = client.GetPlanCheckDetail(p);
	 var gammaSummary = details.Data.GammaSummary;

	 //Get list of files
         var files = client.GetPlanFiles(p);

         var basePath = @"C:\MobiusDownloads\";
         var m3Ddose = files.FirstOrDefault(f => f.FileName.StartsWith("RTDOSE") && f.FileName.Contains("M3D"));
         if (m3Ddose != null)
         {
	    //Download file
            client.DownloadFile(m3Ddose, Path.Combine(basePath, m3Ddose.FileName));
         }

      }
 }

```
