using System.Diagnostics.CodeAnalysis;
using LBPUnion.ProjectLighthouse.Types.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBPUnion.ProjectLighthouse.Controllers;

[ApiController]
[Route("LITTLEBIGPLANETPS3_XML/")]
[Produces("text/plain")]
public class ClientConfigurationController : ControllerBase
{
    [HttpGet("network_settings.nws")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public IActionResult NetworkSettings()
    {
        HostString hostname = this.Request.Host;
        return this.Ok
        (
            "ProbabilityOfPacketDelay 0.0\nMinPacketDelayFrames 0\nMaxPacketDelayFrames 3\nProbabilityOfPacketDrop 0.0\nEnableFakeConditionsForLoopback true\nNumberOfFramesPredictionAllowedForNonLocalPlayer 1000\nEnablePrediction true\nMinPredictedFrames 0\nMaxPredictedFrames 10\nAllowGameRendCameraSplit true\nFramesBeforeAgressiveCatchup 30\nPredictionPadSides 200\nPredictionPadTop 200\nPredictionPadBottom 200\nShowErrorNumbers true\nAllowModeratedLevels false\nAllowModeratedPoppetItems false\nTIMEOUT_WAIT_FOR_JOIN_RESPONSE_FROM_PREV_PARTY_HOST 50.0\nTIMEOUT_WAIT_FOR_CHANGE_LEVEL_PARTY_HOST 30.0\nTIMEOUT_WAIT_FOR_CHANGE_LEVEL_PARTY_MEMBER 45.0\nTIMEOUT_WAIT_FOR_REQUEST_JOIN_FRIEND 15.0\nTIMEOUT_WAIT_FOR_CONNECTION_FROM_HOST 30.0\nTIMEOUT_WAIT_FOR_ROOM_ID_TO_JOIN 60.0\nTIMEOUT_WAIT_FOR_GET_NUM_PLAYERS_ONLINE 60.0\nTIMEOUT_WAIT_FOR_SIGNALLING_CONNECTIONS 120.0\nTIMEOUT_WAIT_FOR_PARTY_DATA 60.0\nTIME_TO_WAIT_FOR_LEAVE_MESSAGE_TO_COME_BACK 20.0\nTIME_TO_WAIT_FOR_FOLLOWING_REQUESTS_TO_ARRIVE 30.0\nTIMEOUT_WAIT_FOR_FINISHED_MIGRATING_HOST 30.0\nTIMEOUT_WAIT_FOR_PARTY_LEADER_FINISH_JOINING 45.0\nTIMEOUT_WAIT_FOR_QUICKPLAY_LEVEL 60.0\nTIMEOUT_WAIT_FOR_PLAYERS_TO_JOIN 30.0\nTIMEOUT_WAIT_FOR_DIVE_IN_PLAYERS 240.0\nTIMEOUT_WAIT_FOR_FIND_BEST_ROOM 60.0\nTIMEOUT_DIVE_IN_TOTAL 300.0\nTIMEOUT_WAIT_FOR_SOCKET_CONNECTION 120.0\nTIMEOUT_WAIT_FOR_REQUEST_RESOURCE_MESSAGE 120.0\nTIMEOUT_WAIT_FOR_LOCAL_CLIENT_TO_GET_RESOURCE_LIST 120.0\nTIMEOUT_WAIT_FOR_CLIENT_TO_LOAD_RESOURCES 120.0\nTIMEOUT_WAIT_FOR_LOCAL_CLIENT_TO_SAVE_GAME_STATE 30.0\nTIMEOUT_WAIT_FOR_ADD_PLAYERS_TO_TAKE 30.0\nTIMEOUT_WAIT_FOR_UPDATE_FROM_CLIENT 90.0\nTIMEOUT_WAIT_FOR_HOST_TO_GET_RESOURCE_LIST 60.0\nTIMEOUT_WAIT_FOR_HOST_TO_SAVE_GAME_STATE 60.0\nTIMEOUT_WAIT_FOR_HOST_TO_ADD_US 30.0\nTIMEOUT_WAIT_FOR_UPDATE 60.0\nTIMEOUT_WAIT_FOR_REQUEST_JOIN 50.0\nTIMEOUT_WAIT_FOR_AUTOJOIN_PRESENCE 60.0\nTIMEOUT_WAIT_FOR_AUTOJOIN_CONNECTION 120.0\nSECONDS_BETWEEN_PINS_AWARDED_UPLOADS 300.0\nEnableKeepAlive true\nAllowVoIPRecordingPlayback true\nOverheatingThresholdDisallowMidgameJoin 0.95\nMaxCatchupFrames 3\nMaxLagBeforeShowLoading 23\nMinLagBeforeHideLoading 30\nLagImprovementInflectionPoint -1.0\nFlickerThreshold 2.0\nClosedDemo2014Version 1\nClosedDemo2014Expired false\nEnablePlayedFilter true\nEnableCommunityDecorations true\nGameStateUpdateRate 10.0\nGameStateUpdateRateWithConsumers 1.0\nDisableDLCPublishCheck false\nEnableDiveIn true\nEnableHackChecks false\n" +
            $"TelemetryServer {hostname}\n" +
            $"CDNHostName {hostname}\n" +
            $"ShowLevelBoos {ServerSettings.Instance.BooingEnabled.ToString().ToLower()}\n" +
            $"AllowOnlineCreate {ServerSettings.Instance.VitaCreateMode.ToString().ToLower()}\n"
        );
    }

    [HttpGet("t_conf")]
    [Produces("text/json")]
    public IActionResult Conf() => this.Ok("[{\"StatusCode\":200}]");

    [HttpGet("farc_hashes")]
    public IActionResult FarcHashes() => this.Ok();

    [HttpGet("privacySettings")]
    [Produces("text/xml")]
    public IActionResult PrivacySettings()
    {
        PrivacySettings ps = new()
        {
            LevelVisibility = "all",
            ProfileVisibility = "all",
        };

        return this.Ok(ps.Serialize());
    }
}