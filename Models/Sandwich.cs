using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
#pragma warning disable 649

// The SandwichOrder is the simple form you want to fill out.  It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked.
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.
namespace Microsoft.Bot.Sample.FormBot
{
    //[Prompt("Where do you feel discomfort?")]
    public enum PainTypes
    {
        Head, Leg, Neck, Hand
    };
    public enum HandPainTypes { Wrist, Hnad, Elbow };
    public enum LegPainTypes { Knee, Leg, Ankle };
    public enum CheeseOptions { American, MontereyCheddar, Pepperjack };
    public enum ToppingOptions
    {
        Avocado, BananaPeppers, Cucumbers, GreenBellPeppers, Jalapenos,
        Lettuce, Olives, Pickles, RedOnion, Spinach, Tomatoes
    };
    public enum SauceOptions
    {
        ChipotleSouthwest, HoneyMustard, LightMayonnaise, RegularMayonnaise,
        Mustard, Oil, Pepper, Ranch, SweetOnion, Vinegar
    };

    [Serializable]
    public class SandwichOrder
    {
        public PainTypes? Specialty;
        public HandPainTypes? Hospitals;
        public LegPainTypes? Bread;
        public CheeseOptions? Cheese;
        public List<ToppingOptions> Toppings;
        public List<SauceOptions> Sauce;

        public static IForm<SandwichOrder> BuildForm()
        {
            OnCompletionAsyncDelegate<SandwichOrder> processOrder = async (context, state) =>
            {
                await context.PostAsync("This is the end of the form, you would give a final confirmation, and then start the ordering process as needed.");
            };
            int i = 0;
            return new FormBuilder<SandwichOrder>()
                    .Message("Hello how may I help You?")
                    .Field(nameof(Specialty))
                    .Message("Thanks for selecting speciality")
                    .Field(nameof(Hospitals), "Let me know where do you feel pain?")
                    .OnCompletion(processOrder)
                    .Build();
        }
    };
}