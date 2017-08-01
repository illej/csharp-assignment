using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilerNS;
using DesignerNS;
using GameNS;

namespace WinFormNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* << VIEWS >> */
            BaseForm baseForm = new BaseForm();
            IGameView gameView = new GameFormView(); // injecting new << View >>
            //IGameView_Render gameView = new GameFormView_Render(); // injecting new << View >>
            //IGameView_Manual gameView = new GameFormView_Manual();
            IFilerView filerView = new FilerFormView();
            IDesignerView designerView = new DesignerFormView();

            /* << MODELS >> */
            IFiler filer = new Filer();
            IDesigner designer = new Designer();
            IFileable designerFileable = (IFileable)designer;
            IGame game = new Game();
            IFileable gameFileable = (IFileable)game;

            /* << CONTROLLER(S) >> */
            IGameController gameController = new GameController(gameView, filerView, filer, game, gameFileable);
            IDesignerController designerController = new DesignerController(filerView, designerView, filer, designer, designerFileable);

            baseForm.SetControllers(gameController, designerController);
            //gameView.SetController(gameController); // Set Controller for injected View
            Application.Run(baseForm);
        }
    }
}
