using NINA.Equipment.Equipment.MyRotator;
using NINA.Core.Locale;
using NINA.Profile.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using ASCOM.Common.DeviceInterfaces;
using NINA.Equipment.Equipment;
using NINA.Equipment.Utility;
using Accord.Math;
using NINA.Core.Utility;
using ASCOM.Com.DriverAccess;
using NINA.Astrometry;
using ASCOM.Common;
using NINA.Equipment.Interfaces;

namespace schmidt.NINA.ManualRotatorOAG.ManualRotatorOAGDrivers {
    //Deriving from both ManualRotator and IRotator seems redundnat, but is not
    //Since the methods we need to override in ManualRotator are not virtual, deriving from the
    //interface again allows us to override them while preserving proper virtual dispatch
    public class ManualRotatorOAGRotatorDriver : ManualRotator, IRotator {

        private ASCOM.Com.DriverAccess.Rotator simulator;

        public ManualRotatorOAGRotatorDriver(IProfileService profileService) : base(profileService) {
        }

        public new string Name => "Manual Rotator + OAG";

        public new string DisplayName => Loc.Instance["LblManualRotator"] + " + OAG";

        private ASCOM.Com.DriverAccess.Rotator GetRotatorSimulator() {
            return new Rotator("ASCOM.Simulator.Rotator");
        }

        public new Task<bool> Connect(CancellationToken token) {
            if (simulator == null)
                simulator = GetRotatorSimulator();

            simulator.Connected = true;
            simulator.MoveAbsolute(Position); //ensure that the ASCOM simulator syncs with the NINA manual rotator position
            return base.Connect(token);
        }

        public new void Disconnect() {
            simulator.Connected = false;
            base.Disconnect();
        }

        public new bool Reverse {
            get => base.Reverse;
            set {
                simulator.Reverse = value;
                base.Reverse = value;
            }
        }

        public new void Sync(float skyAngle) {
            simulator.Sync(skyAngle);
            base.Sync(skyAngle);
        }

        public new async Task<bool> Move(float position, CancellationToken ct) {
            //move BOTH the actual ASCOM Simulator and the NINA manual rotator
            Task[] tasks = { simulator.MoveAsync(position, ct), base.Move(position, ct) };
            await Task.WhenAll(tasks);
            return true;
        }

        public new async Task<bool> MoveAbsolute(float position, CancellationToken ct) {
            return await Move(position - Position, ct);
        }

        public new async Task<bool> MoveAbsoluteMechanical(float position, CancellationToken ct) {
            return await MoveAbsolute(position, ct);
        }
    }
}
