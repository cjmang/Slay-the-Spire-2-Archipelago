using HarmonyLib;
using MegaCrit.Sts2.Core.Events;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StS2AP.Patches
{
    [HarmonyPatch(typeof(AncientEventModel), "GenerateInitialOptionsWrapper")]
    public static class Patches_AncientRelics
    {
        [HarmonyPostfix]
        public static void ReplaceAncientOptions(AncientEventModel __instance, ref IReadOnlyList<EventOption> __result)
        {
            List<EventOption> newResult = new List<EventOption>();
            int max = Math.Max(3, __result.Count());
            for(int i=0; i < max; i++)
            {
                newResult.Add(CreateFakeOption(__instance));
            }
            __result = newResult;
        }

        private static EventOption CreateFakeOption(AncientEventModel ancient)
        {
            return new EventOption(ancient, NEventRoom.Proceed, "PROCEED", false, true);
        }
    }
}
