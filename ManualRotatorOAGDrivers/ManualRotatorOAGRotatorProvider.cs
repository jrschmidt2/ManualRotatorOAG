using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Profile.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace schmidt.NINA.ManualRotatorOAG.ManualRotatorOAGDrivers {
    /// <summary>
    /// This Class shows the basic principle on how to add a new Device driver to N.I.N.A. via the plugin interface
    /// When the application scans for equipment the "GetEquipment" method of a device provider is called.
    /// This method should then return the specific List of Devices that you can connect to
    /// </summary>
    [Export(typeof(IEquipmentProvider))]
    public class ManualRotatorOAGRotatorProvider : IEquipmentProvider<IRotator> {
        private IProfileService profileService;

        [ImportingConstructor]
        public ManualRotatorOAGRotatorProvider(IProfileService profileService) {
            this.profileService = profileService;
        }

        public string Name => "Manualrotatoroag";

        public IList<IRotator> GetEquipment() {
            var devices = new List<IRotator>();
            devices.Add(new ManualRotatorOAGRotatorDriver(profileService));

            return devices;
        }
    }
}
