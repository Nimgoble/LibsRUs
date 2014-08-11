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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Seed the Libs
            var libs = new Lib[]
            {
                new Lib{Name="WPF Textbox AutoComplete", Description="An attached behavior for WPF's TextBox control that provides auto-completion suggestions from a given collection", LibURL="https://github.com/Nimgoble/WPFTextBoxAutoComplete"},
                new Lib{Name="Simple DirectMedia Layer", Description="Simple DirectMedia Layer is a cross-platform development library designed to provide low level access to audio, keyboard, mouse, joystick, and graphics hardware via OpenGL and Direct3D. It is used by video playback software, emulators, and popular games including Valve's award winning catalog and many Humble Bundle games.", LibURL="https://www.libsdl.org/"},
                new Lib{Name="Box2D", Description="Box2D is an open source C++ engine for simulating rigid bodies in 2D. Box2D is developed by Erin Catto and has the zlib license. While the zlib license does not require acknowledgement, we encourage you to give credit to Box2D in your product.", LibURL="http://box2d.org/"},
                new Lib{Name="iTextSharp", Description="iText is a PDF library that allows you to CREATE, ADAPT, INSPECT and MAINTAIN documents in the Portable Document Format (PDF).", LibURL="http://sourceforge.net/projects/itextsharp/"}
            };
            //context.Libs.
            //libs.ForEach(x => context.Libs.AddOrUpdate(h => h.Name, x));
            context.Libs.AddOrUpdate(h => h.Name, libs);
            context.SaveChanges();

            var tagTypes = new LibTagType[]
            {
                new LibTagType() {Name = "Category"},
                new LibTagType() {Name = "Programming Language"},
                new LibTagType() {Name = "Platform"}
            };
            context.LibTagTypes.AddOrUpdate(h => h.Name, tagTypes);
            context.SaveChanges();

            LibTagType categoryType = context.LibTagTypes.SingleOrDefault(x => x.Name == "Category");
            //Seed the Tags
            var tags = new LibTag[]
            {
                new LibTag{TagText="PDF", Description="All libraries dealing the with creation/modification of PDFs"},
                new LibTag{TagText="PDF Rasterizer", Description="All libraries dealing with rasterizing PDFs"},
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
                new LibTag{TagText="Open Source", Description="All libraries that are open source"},
                new LibTag{TagText="jQuery"},
                new LibTag{TagText="MVC", Description="All libraries dealing with the Model-View-Controller pattern"}
            };

            foreach (LibTag libTag in tags)
                libTag.LibTagType = categoryType;

            //tags.ForEach(x => context.LibTags.AddOrUpdate(h => h.TagText, x));
            context.LibTags.AddOrUpdate(h => h.TagText, tags);
            context.SaveChanges();

            LibTagType programmingLanguageType = context.LibTagTypes.SingleOrDefault(x => x.Name == "Programming Language");
            //Seed the ProgrammingLanguages
            var programmingLanguages = new LibTag[]
            {
                new LibTag{TagText="C", LibTagType = programmingLanguageType},
                new LibTag{TagText="C++", LibTagType = programmingLanguageType},
                new LibTag{TagText="C#", LibTagType = programmingLanguageType},
                new LibTag{TagText="Visual Basic", LibTagType = programmingLanguageType},
                new LibTag{TagText="Javascript", LibTagType = programmingLanguageType},
                new LibTag{TagText="Java", LibTagType = programmingLanguageType},
                new LibTag{TagText="Python", LibTagType = programmingLanguageType},
                new LibTag{TagText="Ruby", LibTagType = programmingLanguageType},
                new LibTag{TagText="Objective-C", LibTagType = programmingLanguageType},
                new LibTag{TagText="PHP", LibTagType = programmingLanguageType},
                new LibTag{TagText="Perl", LibTagType = programmingLanguageType},
                new LibTag{TagText="ActionScript", LibTagType = programmingLanguageType},
                new LibTag{TagText="Ada", LibTagType = programmingLanguageType},
                new LibTag{TagText="Go", LibTagType = programmingLanguageType},
                new LibTag{TagText="Lua", LibTagType = programmingLanguageType},
                new LibTag{TagText="Brainfuck", LibTagType = programmingLanguageType}
            };
            //programmingLanguages.ForEach(x => context.ProgrammingLanguages.AddOrUpdate(h => h.Name, x));
            context.LibTags.AddOrUpdate(h => h.TagText, programmingLanguages);
            context.SaveChanges();

            LibTagType platformType = context.LibTagTypes.SingleOrDefault(x => x.Name == "Platform");
            //Seed the Platforms
            var platforms = new LibTag[]
            {
                new LibTag{TagText="Windows", LibTagType = platformType},
                new LibTag{TagText="Windows Phone", LibTagType = platformType},
                new LibTag{TagText="Linux", LibTagType = platformType},
                new LibTag{TagText="Mac OS", LibTagType = platformType},
                new LibTag{TagText="iOS", LibTagType = platformType},
                new LibTag{TagText="Android", LibTagType = platformType}
            };
            //platforms.ForEach(x => context.Platforms.AddOrUpdate(h => h.Name, x));
            context.LibTags.AddOrUpdate(h => h.TagText, platforms);
            context.SaveChanges();

            //Add tags, languages, and platforms to the 'WPF Textbox Autocomplete' lib
            Lib wpfTextBoxAutoComplete = context.Libs.Single(x => x.Name == "WPF Textbox AutoComplete");
            //Tags
            var relevantLibTags = context.LibTags.Where(x => x.TagText == "WPF" || x.TagText == ".NET" || x.TagText == "Auto-Completion").ToList();
            relevantLibTags.ForEach(x => { wpfTextBoxAutoComplete.LibTags.Add(x); x.Libs.Add(wpfTextBoxAutoComplete); });
            context.SaveChanges();

            //Programming Languages
            LibTag relevantProgrammingLanguage = context.LibTags.Single(x => x.TagText == "C#" && x.LibTagType.Name == "Programming Language");
            wpfTextBoxAutoComplete.LibTags.Add(relevantProgrammingLanguage);
            relevantProgrammingLanguage.Libs.Add(wpfTextBoxAutoComplete);
            context.SaveChanges();

            //Platforms
            var relevantPlatforms = context.LibTags.Where(x => (x.TagText == "Windows" || x.TagText == "Windows Phone") && x.LibTagType.Name == "Platform").ToList();
            relevantPlatforms.ForEach(x => { wpfTextBoxAutoComplete.LibTags.Add(x); x.Libs.Add(wpfTextBoxAutoComplete); });
            context.SaveChanges();
        }
    }
}
