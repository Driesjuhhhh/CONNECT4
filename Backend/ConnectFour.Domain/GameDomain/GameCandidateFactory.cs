﻿using ConnectFour.Domain.GameDomain.Contracts;

namespace ConnectFour.Domain.GameDomain;

/// <inheritdoc cref="IGameCandidateFactory"/>
public class GameCandidateFactory : IGameCandidateFactory
{
    public IGameCandidate CreateNewForUser(User user, GameSettings settings)
    {
        return new GameCandidate(user, settings);
    }
}