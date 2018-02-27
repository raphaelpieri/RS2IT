﻿using GameService.Shared.Commands;

namespace GameServices.Domain.GamesContext.Commands.GameCompanyCommands.Outputs
{
    public class GameCompanyCommandResult : ICommandResult
    {
        public GameCompanyCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}