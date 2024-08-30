using ClosedLoopEconomicsGame.Model.GameModels;
using ClosedLoopEconomicsGame.View.Controls.GameControls;
using Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.Helpers.GameHelpers;
using ClosedLoopEconomicsGame.Model;
using ClosedLoopEconomicsGame.ViewModel.Popups;

namespace ClosedLoopEconomicsGame.ViewModel.Pages
{
    internal class GamePageViewModel : ObservableObject
    {
        public ObservableCollection<GameObject> GameObjects
        {
            get => GetOrCreate<ObservableCollection<GameObject>>();
            set => SetAndNotify(value);
        }

        public GameObject? SelectedGameObject
        {
            get => GetOrCreate<GameObject?>();
            set => SetAndNotify(value);
        }

        public IGameOverlayController GameOverlayController
        {
            get => GetOrCreate<IGameOverlayController>();
            set => SetAndNotify(value);
        }

        public ICountdownTimerController CountdownTimerController
        {
            get => GetOrCreate<ICountdownTimerController>();
            set => SetAndNotify(value);
        }

        public int CorrectAnswersCount
        {
            get => GetOrCreate<int>();
            set => SetAndNotify(value, callback: _ =>
                SoundHelper.CorrectAnswerSound.Play());
        }

        public int WrongAnswersCount
        {
            get => GetOrCreate<int>();
            set => SetAndNotify(value, callback: _ =>
                SoundHelper.WrongAnswerSound.Play());
        }

        public GamePageViewModel()
        {
            var gameObjects = GetObjects()
                .Select(model => new GameObject
                {
                    Model = model
                });
            GameObjects = new ObservableCollection<GameObject>(gameObjects);
        }

        private List<GameObjectModel> GetObjects()
        {
            var random = new Random();
            var list = new List<GameObjectModel>();
            list.AddRange(ContentManager.GetObjectsByCategory("Бумага").OrderBy(_ => random.NextDouble()).Take(12));
            list.AddRange(ContentManager.GetObjectsByCategory("Пластик").OrderBy(_ => random.NextDouble()).Take(12));
            list.AddRange(ContentManager.GetObjectsByCategory("Металл").OrderBy(_ => random.NextDouble()).Take(12));
            list.AddRange(ContentManager.GetObjectsByCategory("Стекло").OrderBy(_ => random.NextDouble()).Take(12));
            return list;
        }

        public ICommand OnGameObjectAreaLoadedCommand => GetOrCreate(new RelayCommand(obj =>
        {
            if (obj is not IGameObjectAreaController gameObjectAreaController)
                return;

            gameObjectAreaController.ArrangeGameObjects();
        }));

        public ICommand OnTimeIsOverCommand => GetOrCreate(new RelayCommand(obj =>
        {
            WrongAnswersCount += GameObjects.Count;
            EndGame();
        }));

        public ICommand GameObjectContainerCommand => GetOrCreate(new RelayCommand(obj =>
        {
            if (obj is not GameObjectContainer container ||
                SelectedGameObject is null)
                return;

            var selectedGameObject = SelectedGameObject;
            SelectedGameObject = null;

            var gameObjectCenterPosition = GameOverlayController.GetPositionOfElementCenter(selectedGameObject);
            var containerCenterPosition = GameOverlayController.GetPositionOfElementCenter(container);
            var offset = containerCenterPosition - gameObjectCenterPosition;

            selectedGameObject.IsHitTestVisible = false;

            selectedGameObject.Move(offset.X, offset.Y, _ =>
            {
                CheckAnswer(selectedGameObject, container);
            });
        }));

        private void CheckAnswer(GameObject gameObject, GameObjectContainer container)
        {
            if (gameObject.Model.CategoryName?.Equals(container.CategoryName, StringComparison.OrdinalIgnoreCase) == true)
            {
                CorrectAnswersCount++;

                gameObject.AnswerCorrectnessDisplayControl.ShowCorrectAnswer(answerControl =>
                {
                    gameObject.Hide(GameObjectHideCallback);
                });

                return;
            }

            WrongAnswersCount++;

            gameObject.AnswerCorrectnessDisplayControl.ShowWrongAnswer(answerControl =>
            {
                gameObject.Move(0, 0, _ => gameObject.IsHitTestVisible = true);
                answerControl.HideAnswer();
            });
        }

        private void GameObjectHideCallback(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
            CheckGameIsOver();
        }

        private void CheckGameIsOver()
        {
            if (GameObjects.Any())
                return;

            EndGame();
        }

        private void EndGame()
        {
            CountdownTimerController.Stop();
           //ShowResult();
           var result = new ResultGameModel();
           
           if (WrongAnswersCount > CorrectAnswersCount)
           {
               result = new ResultGameModel
               {
                   Title = "Плохо!",
                   Description = "Попробуй еще раз",
                   ImagePath = "Content/EndGamePopup/SadImagePopup.png",
                   Replay = true
               };
               SoundHelper.LoseGameEndedSound.Play();
           }
           else if (WrongAnswersCount <= CorrectAnswersCount)
           {
               result = new ResultGameModel
               {
                   Title = "Неплохо!",
                   Description = "Ты хорошо справился с игрой",
                   ImagePath = "Content/EndGamePopup/WinnerImagePopup.png",
                   Replay = false
               };
               SoundHelper.GameEndedSound.Play();
            }
            if (WrongAnswersCount <= 10)
            {
               result = new ResultGameModel
               {
                   Title = "Молодец!",
                   Description = "Ты успешно справился с игрой",
                   ImagePath = "Content/EndGamePopup/WinnerImagePopup.png",
                   Replay = false
               };
            }
            CommonCommands.OpenPopupCommand.Execute(result);
        }

        public ICommand ExitGameCommand => GetOrCreate(new RelayCommand(f =>
        {
            CountdownTimerController.Pause();
            var exitGamePopupViewModel = new ExitGamePopupViewModel(CountdownTimerController);
            CommonCommands.OpenPopupCommand.Execute(exitGamePopupViewModel);
        }));

        private void ShowResult()
        {
            //var score = CorrectAnswersCount - WrongAnswersCount;

            //BestScoreHelper.CheckAndSave(score);
            //SoundHelper.GameEndedSound.Play();

            //PopupManager.MainOverlay?.OpenContent(new GameResultPopup
            //{
            //    CorrectAnswers = CorrectAnswersCount,
            //    WrongAnswers = WrongAnswersCount,
            //    Score = score,
            //    BestScore = BestScoreHelper.Get()
            //});
        }
    }
}
