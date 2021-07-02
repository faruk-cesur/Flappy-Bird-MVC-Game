using UnityEngine;

    public class Controller
    {
        public PlayerView playerView;
        public Model model;

        public Controller(Model model, PlayerView view)
        {
            this.model = model;
            this.playerView = view;
        }

        private void Start()
        {
            
        }
    }