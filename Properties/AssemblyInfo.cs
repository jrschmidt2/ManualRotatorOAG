using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// [MANDATORY] The following GUID is used as a unique identifier of the plugin. Generate a fresh one for your plugin!
[assembly: Guid("994418ae-1c2f-4b66-b61f-585c450277e8")]

// [MANDATORY] The assembly versioning
//Should be incremented for each new release build of a plugin
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

// [MANDATORY] The name of your plugin
[assembly: AssemblyTitle("ManualRotatorOAG")]
// [MANDATORY] A short description of your plugin
[assembly: AssemblyDescription("Manual rotator with support for an OAG with PHD2 integration")]

// The following attributes are not required for the plugin per se, but are required by the official manifest meta data

// Your name
[assembly: AssemblyCompany("JR Schmidt")]
// The product name that this plugin is part of
[assembly: AssemblyProduct("ManualRotatorOAG")]
[assembly: AssemblyCopyright("Copyright © 2024 JR Schmidt")]

// The minimum Version of N.I.N.A. that this plugin is compatible with
[assembly: AssemblyMetadata("MinimumApplicationVersion", "3.0.0.2017")]

// The license your plugin code is using
[assembly: AssemblyMetadata("License", "MPL-2.0")]
// The url to the license
[assembly: AssemblyMetadata("LicenseURL", "https://www.mozilla.org/en-US/MPL/2.0/")]
// The repository where your pluggin is hosted
[assembly: AssemblyMetadata("Repository", "https://github.com/jrschmidt2/ManualRotatorOAG")]

// The following attributes are optional for the official manifest meta data

//[Optional] Common tags that quickly describe your plugin
[assembly: AssemblyMetadata("Tags", "manual, rotator, OAG")]

//[Optional] A link that will show a log of all changes in between your plugin's versions
[assembly: AssemblyMetadata("ChangelogURL", "https://github.com/jrschmidt2/ManualRotatorOAG/blob/master/CHANGELOG.md")]

//[Optional] The url to a featured logo that will be displayed in the plugin list next to the name
[assembly: AssemblyMetadata("FeaturedImageURL", "")]
//[Optional] A url to an example screenshot of your plugin in action
[assembly: AssemblyMetadata("ScreenshotURL", "")]
//[Optional] An additional url to an example example screenshot of your plugin in action
[assembly: AssemblyMetadata("AltScreenshotURL", "")]
//[Optional] An in-depth description of your plugin
[assembly: AssemblyMetadata("LongDescription",
    @"Manual rotator with support for an OAG with PHD2 integration.
Extends the function of the normal NINA manual rotator to allow for integration with PHD2
when using an off-axis guider (OAG). Since the OAG rotates along with the rotator, this typically would require
a new calibration with every manual rotation. This plugin uses the ASCOM rotator simulator as an
intermediary to communicate the current camera rotation angle to PHD2. This allows for the use of
the manual rotator with requiring PHD2 recalibration.

--Detailed instructions--

INITIAL SETUP (one time only)

* NINA:
 - Install the ManualRotatorOAG plugin
 - Under Equipment : Rotator, select the 'Manual Rotator + OAG'

* PHD2:
 - Under Equipment (More Equipment) : Rotator, add the 'Rotator Simulator .NET (ASCOM)' 
 - Under Guide : Advanced Settings : Other Devices, click the 'Reverse sign of angle' checkbox
   (necessary since NINA and PHD2 use opposite conventions for the rotation angle)
 - After syncing the rotator position to the correct sky angle (see USAGE), perform an initial PHD2 calibration

USAGE (every time)

(1) Sync manual rotator to current camera angle. (This is necessary only after initial setup OR if the camera
has been moved outside of the NINA manual rotator [e.g. not using a NINA Slew, Center, Rotate]) A simple way
of doing this is to:
 (a) Use the 'Rotation From Camera' button to determine the current camera angle
 (b) Under Equipment : Rotator, manually set the rotator to this angle
Any future rotations using the Manual Rotator tool will automatically keep things in sync.

(2) Use the Framing assistant, find the desired camera angle, and execute a Slew, Center, Rotate
command. After completion of the rotation (using the Manual Rotator tool), the final camera angle
will be communicated to PHD2 (via the ASCOM Rotator simulator), which will adjust the guiding accordingly.
No new calibration is required!

")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
// [Unused]
[assembly: AssemblyConfiguration("")]
// [Unused]
[assembly: AssemblyTrademark("")]
// [Unused]
[assembly: AssemblyCulture("")]