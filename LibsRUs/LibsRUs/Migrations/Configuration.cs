namespace LibsRUs.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibsRUs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LibsRUs.DAL.LibsRUsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LibsRUs.DAL.LibsRUsContext";
        }

        protected override void Seed(LibsRUs.DAL.LibsRUsContext context)
        {
            DebugSection("Begin Libs");
            context.Libs.ToList().ForEach(x => context.Libs.Remove(x));
            //Seed the Libs
            var libs = new List<Lib>
            {
                new Lib{Name="WPF Textbox AutoComplete", Description="An attached behavior for WPF's TextBox control that provides auto-completion suggestions from a given collection", LibURL="https://github.com/Nimgoble/WPFTextBoxAutoComplete"},
                new Lib{Name="Simple DirectMedia Layer", Description="Simple DirectMedia Layer is a cross-platform development library designed to provide low level access to audio, keyboard, mouse, joystick, and graphics hardware via OpenGL and Direct3D. It is used by video playback software, emulators, and popular games including Valve's award winning catalog and many Humble Bundle games.", LibURL="https://www.libsdl.org/"},
                new Lib{Name="Box2D", Description="Box2D is an open source C++ engine for simulating rigid bodies in 2D. Box2D is developed by Erin Catto and has the zlib license. While the zlib license does not require acknowledgement, we encourage you to give credit to Box2D in your product.", LibURL="http://box2d.org/"},
                new Lib{Name="iTextSharp", Description="iText is a PDF library that allows you to CREATE, ADAPT, INSPECT and MAINTAIN documents in the Portable Document Format (PDF).", LibURL="http://sourceforge.net/projects/itextsharp/"}
            };
            //context.Libs.
            libs.ForEach(x => context.Libs.AddOrUpdate(x));
            context.SaveChanges();
            DebugSection("End Libs");

            DebugSection("Begin Tags");
            //Seed the Tags
            var tags = new List<LibTag>
            {
                new LibTag{TagText="PDF"},
                new LibTag{TagText="PDF Rasterizer"},
                new LibTag{TagText="Game Development"},
                new LibTag{TagText="Game Programming"},
                new LibTag{TagText="Physics"},
                new LibTag{TagText="Cross-Platform"},
                new LibTag{TagText="WPF"},
                new LibTag{TagText=".NET"},
                new LibTag{TagText="Auto-Completion"},
                new LibTag{TagText="Media"},
                new LibTag{TagText="2D"},
                new LibTag{TagText="3D"},
                new LibTag{TagText="Open Source"},
                new LibTag{TagText="jQuery"},
                new LibTag{TagText="MVC"}
            };
            tags.ForEach(x => context.LibTags.AddOrUpdate(x));
            context.SaveChanges();
            DebugSection("End Tags");

            DebugSection("Begin ProgrammingLanguages");
            //Seed the ProgrammingLanguages
            var programmingLanguages = new List<ProgrammingLanguage>
            {
                new ProgrammingLanguage{Name="C"},
                new ProgrammingLanguage{Name="C++"},
                new ProgrammingLanguage{Name="C#"},
                new ProgrammingLanguage{Name="Visual Basic", Abbreviation="VB"},
                new ProgrammingLanguage{Name="Javascript", Abbreviation="js"},
                new ProgrammingLanguage{Name="Java"},
                new ProgrammingLanguage{Name="Python"},
                new ProgrammingLanguage{Name="Ruby"},
                new ProgrammingLanguage{Name="Objective-C"},
                new ProgrammingLanguage{Name="PHP"},
                new ProgrammingLanguage{Name="Perl"},
                new ProgrammingLanguage{Name="ActionScript"},
                new ProgrammingLanguage{Name="Ada"},
                new ProgrammingLanguage{Name="Go"},
                new ProgrammingLanguage{Name="Lua"},
                new ProgrammingLanguage{Name="Brainfuck"}
            };
            programmingLanguages.ForEach(x => context.ProgrammingLanguages.AddOrUpdate(x));
            context.SaveChanges();
            DebugSection("End ProgrammingLanguages");

            DebugSection("Begin Platforms");
            //Seed the Platforms
            var platforms = new List<Platform>
            {
                new Platform{Name="Windows"},
                new Platform{Name="Windows Phone"},
                new Platform{Name="Linux"},
                new Platform{Name="Mac OS"},
                new Platform{Name="iOS"},
                new Platform{Name="Android"}
            };
            platforms.ForEach(x => context.Platforms.AddOrUpdate(x));
            context.SaveChanges();
            DebugSection("End Platforms");

            //Add tags, languages, and platforms to the 'WPF Textbox Autocomplete' lib
            Lib wpfTextBoxAutoComplete = context.Libs.Single(x => x.Name == "WPF Textbox AutoComplete");
            //Tags
            DebugSection("Begin add tags to test lib");
            var relevantLibTags = context.LibTags.Where(x => x.TagText == "WPF" || x.TagText == ".NET" || x.TagText == "Auto-Completion").ToList();
            relevantLibTags.ForEach(x => { wpfTextBoxAutoComplete.LibTags.Add(x); x.Libs.Add(wpfTextBoxAutoComplete); });
            context.SaveChanges();
            DebugSection("End add tags to test lib");

            DebugSection("Begin add ProgrammingLanguage to test lib");
            //Programming Languages
            ProgrammingLanguage relevantProgrammingLanguage = context.ProgrammingLanguages.Single(x => x.Name == "C#");
            wpfTextBoxAutoComplete.ProgrammingLanguages.Add(relevantProgrammingLanguage);
            relevantProgrammingLanguage.Libs.Add(wpfTextBoxAutoComplete);
            context.SaveChanges();
            DebugSection("End add ProgrammingLanguage to test lib");

            DebugSection("Begin add Platforms to test lib");
            //Platforms
            var relevantPlatforms = context.Platforms.Where(x => x.Name == "Windows" || x.Name == "Windows Phone").ToList();
            relevantPlatforms.ForEach(x => { wpfTextBoxAutoComplete.Platforms.Add(x); x.Libs.Add(wpfTextBoxAutoComplete); });
            context.SaveChanges();
            DebugSection("End add Platforms to test lib");
        }
        private void DebugSection(String section)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("===============================================================");
            Console.WriteLine(section);
            Console.WriteLine("===============================================================");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
