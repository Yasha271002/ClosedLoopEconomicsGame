using System.IO;
using System.Windows.Media;
using ClosedLoopEconomicsGame.Utilities.Logging;

namespace ClosedLoopEconomicsGame.Helpers.GameHelpers
{
    public class SoundHelper
    {
        private MediaPlayer? _player;

        public static SoundHelper CorrectAnswerSound { get; private set; }
        public static SoundHelper WrongAnswerSound { get; private set; }
        public static SoundHelper GameEndedSound { get; private set; }
        public static SoundHelper LoseGameEndedSound { get; private set; }

        static SoundHelper()
        {
            
        }

        private SoundHelper(string name)
        {
            _player = TryLoad(name);
        }

        public void Play()
        {
            if (_player is null)
                return;

            _player.Stop();
            _player.Position = TimeSpan.Zero;
            _player.Play();
        }

        public static void Load()
        {
            CorrectAnswerSound = new SoundHelper("correct_answer");
            WrongAnswerSound = new SoundHelper("wrong_answer");
            GameEndedSound = new SoundHelper("game_ended");
            LoseGameEndedSound = new SoundHelper("lose_game_ended");
        }

        private static MediaPlayer? TryLoad(string? name)
        {
            if (name == null)
                return null;

            var path = GetFilePath(name);

            if (path == null)
                return null;

            try
            {
                var mediaPlayer = new MediaPlayer();
                mediaPlayer.Volume = 0.6;
                mediaPlayer.Open(new Uri(path, UriKind.RelativeOrAbsolute));
                return mediaPlayer;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        private static string? GetFilePath(string? name)
        {
            var directory = Path.Combine("sounds");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var files = Directory.GetFiles(directory).ToList();

            return Directory.GetFiles(directory)
                .FirstOrDefault(file => Path.GetFileNameWithoutExtension(file) == name);
        }
    }
}
