using System;
using CitizenFX;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Threading.Tasks;
//using System.Windows.Forms;


namespace SirenCutout
{
    public class Main : BaseScript
    {
        // Declare any variables here
        public Main()
        {           
           base.Tick += OnTick;
        }

       public async Task OnTick()
        {
            var ped = GetPlayerPed(-1);

            if (
                DoesEntityExist(ped) &&
                IsPedInAnyVehicle(ped, false) &&
                !IsEntityDead(ped) &&
                !IsPauseMenuActive() &&
                IsControlJustPressed(2, 75)
                )
            {
                var vehicle = GetVehiclePedIsIn(ped, false);

                if (IsVehicleSirenOn(vehicle))
                {
                    // Send it 4 times, for some reason... 
                    for (int index = 0; index < 4; ++index)
                    {
                        // SendKeys.Send("J");
                        //SetVehicleSiren(vehicle, false);
                    }

                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[SirenCutout]", $"You left your siren on, idiot!" }
                    });
                }
            }

            await Task.FromResult(1);
        }

    }
}
