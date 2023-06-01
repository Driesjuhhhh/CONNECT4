using ConnectFour.AppLogic.Contracts;
using ConnectFour.Domain;
using ConnectFour.Domain.GameDomain;
using ConnectFour.Domain.GameDomain.Contracts;
using System.Xml.Linq;

namespace ConnectFour.AppLogic;

/// <inheritdoc cref="IGameService"/>
internal class GameService : IGameService
{
    private readonly IGameFactory gameFactory;
    private readonly IGameRepository gameRepository;
    public GameService(
        IGameFactory gameFactory,
        IGameRepository gameRepository)
    {
        this.gameFactory = gameFactory;
        this.gameRepository = gameRepository;
    }

    public IGame CreateGameForUsers(User user1, User user2, GameSettings settings)
    {
        IGame newGame = gameFactory.CreateNewTwoPlayerGame(settings, user1, user2);
        gameRepository.Add(newGame);
        return newGame;
    }

    public IGame GetById(Guid gameId)
    {
        return gameRepository.GetById(gameId);
    }

    public void ExecuteMove(Guid gameId, Guid playerId, IMove move)
    {
        IGame game = gameRepository.GetById(gameId);
        game.ExecuteMove(playerId, move);
    }

    public IGame CreateSinglePlayerGameForUser(User user, GameSettings settings)
    {
        IGame newGame = gameFactory.CreateNewSinglePlayerGame(settings, user);

        gameRepository.Add(newGame);

        return newGame;
    }
}