﻿using ConnectFour.AppLogic.Contracts;
using ConnectFour.Domain.GameDomain.Contracts;

namespace ConnectFour.AppLogic;

/// <inheritdoc cref="IGameCandidateMatcher"/>
public class BasicGameCandidateMatcher : IGameCandidateMatcher
{
    public IGameCandidate SelectOpponentToChallenge(IList<IGameCandidate> possibleOpponents)
    {
        if (possibleOpponents == null || possibleOpponents.Count == 0)
        {
            return null;
        }

        return possibleOpponents[0];
    }
}