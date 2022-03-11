﻿using Newtonsoft.Json;
using Transmission.API.RPC.Common;
using static Transmission.API.RPC.Entity.TorrentFields;

namespace Transmission.API.RPC.Entity
{
    public interface ITorrentInfo : ITorrentAttributes
    {
        /// <summary>
        /// The torrent's unique Id.
        /// </summary>
        [JsonProperty(ID)]
        int Id { get; set; }

        /// <summary>
        /// The last time we uploaded or downloaded piece data on this torrent.
        /// </summary>
        [JsonProperty(ACTIVITY_DATE)]
        public long ActivityDate { get; set; }

        /// <summary>
        /// When the torrent was first added.
        /// </summary>
        [JsonProperty(ADDED_DATE)]
        public long AddedDate { get; set; }

        [JsonProperty(COMMENT)]
        public string Comment { get; set; }

        /// <summary>
        /// Byte count of all the corrupt data you've ever downloaded for
        /// this torrent.If you're on a poisoned torrent, this number can
        /// grow very large.
        /// </summary>
        [JsonProperty(CORRUPT_EVER)]
        public int CorruptEver { get; set; }

        [JsonProperty(CREATOR)]
        public string    Creator { get; set; }

        [JsonProperty(DATE_CREATED)]
        public long DateCreated { get; set; }

        /// <summary>
        /// Byte count of all the piece data we want and don't have yet,
        /// but that a connected peer does have. [0...<see cref="LeftUntilDone"/>]
        /// </summary>
        [JsonProperty(DESIRED_AVAILABLE)]
        public long DesiredAvailable { get; set; }

        /// <summary>
        /// When the torrent finished downloading.
        /// </summary>
        [JsonProperty(DONE_DATE)]
        public long DoneDate { get; set; }

        [JsonProperty(DOWNLOAD_DIR)]
        public string DownloadDir { get; set; }

        /// <summary>
        /// Byte count of all the non-corrupt data you've ever downloaded
        /// for this torrent. If you delete the files and download them a
        /// second time, this will be 2 * <see cref="TotalSize"/>..
        /// </summary>
        [JsonProperty(DOWNLOADED_EVER)]
        public long DownloadedEver { get; set; }

        /// <summary>
        /// The last time during this session that a rarely-changing field
        /// changed -- e.g.any tr_torrent_metainfo field(trackers, filenames, name)
        /// or download directory.RPC clients can monitor this to know when
        /// to reload fields that rarely change.
        /// </summary>
        [JsonProperty(EDIT_DATE)]
        public long EditDate { get; set; }

        /// <summary>
        /// Defines what kind of text is in errorString.
        /// 
        /// See <seealso cref="ErrorString"/>
        /// </summary>
        [JsonProperty(ERROR)]
        public TorrentError Error { get; set; }

        /// <summary>
        /// A warning or error message regarding the torrent.
        /// 
        /// <seealso cref="Error"/>
        /// </summary>
        [JsonProperty(ERROR_STRING)]
        public string ErrorString { get; set; }

        /// <summary>
        /// If downloading, estimated number of seconds left until the torrent is done.
        /// If seeding, estimated number of seconds left until seed ratio is reached.
        /// </summary>
        [JsonProperty(ETA)]
        public int Eta { get; set; }

        /// <summary>
        /// If seeding, number of seconds left until the idle time limit is reached.
        /// </summary>
        [JsonProperty(ETA_IDLE)]
        public int EtaIdle { get; set; }

        [JsonProperty(FILE_COUNT)]
        public int FileCount { get; set; }

        [JsonProperty(FILES)]
        public ITransmissionTorrentFile[] Files { get; set; }

        [JsonProperty(FILE_STATS)]
        public ITransmissionTorrentFileStats[] FileStats { get; set; }

        [JsonProperty(HASH_STRING)]
        public string HashString { get; set; }

        /// <summary>
        /// Byte count of all the partial piece data we have for this torrent.
        /// 
        /// As pieces become complete, this value may decrease as portions of it
        /// are moved to <see cref="CorruptEver"/> or <see cref="HaveValid"/>.
        /// </summary>
        [JsonProperty(HAVE_UNCHECKED)]
        public int HaveUnchecked { get; set; }

        /// <summary>
        /// Byte count of all the checksum-verified data we have for this torrent.
        /// </summary>
        [JsonProperty(HAVE_VALID)]
        public long HaveValid { get; set; }

        /// <summary>
        /// A torrent is considered finished if it has met its seed ratio.
        /// As a result, only paused torrents can be finished.
        /// </summary>
        [JsonProperty(IS_FINISHED)]
        public bool IsFinished { get; set; }

        [JsonProperty(IS_PRIVATE)]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// <see langword="true"/> if the torrent is running, but has been idle for long enough
        /// to be considered stalled.
        /// 
        /// See <seealso cref="SessionInfo.QueueStalledMinutes"/>
        /// </summary>
        [JsonProperty(IS_STALLED)]
        public bool IsStalled { get; set; }

        /// <summary>
        /// Byte count of how much data is left to be downloaded until we've got
        /// all the pieces that we want. [0..<see cref="SizeWhenDone"/>]
        /// </summary>
        [JsonProperty(LEFT_UNTIL_DONE)]
        public long LeftUntilDone { get; set; }

        [JsonProperty(MAGNET_LINK)]
        public string MagnetLink { get; set; }

        /// <summary>
        /// Time when one or more of the torrent's trackers will
        /// allow you to manually ask for more peers, or 0 if you
        /// can't
        /// </summary>
        [JsonProperty(MANUAL_ANNOUNCE_TIME)]
        public int ManualAnnounceTime { get; set; }

        [JsonProperty(MAX_CONNECTED_PEERS)]
        public int MaxConnectedPeers { get; set; }

        /// <summary>
        /// How much of the metadata the torrent has.
        /// For torrents added from a.torrent this will always be 1.
        /// For magnet links, this number will from from 0 to 1 as the metadata is downloaded.
        /// Range is [0..1] 
        /// </summary>
        [JsonProperty(METADATA_PERCENT_COMPLETE)]
        public double MetadataPercentComplete { get; set; }

        [JsonProperty(NAME)]
        public string Name { get; set; }

        [JsonProperty(PEERS)]
        public ITransmissionTorrentPeers[] Peers { get; set; }

        /// <summary>
        /// Number of peers that we're connected to
        /// </summary>
        [JsonProperty(PEERS_CONNECTED)]
        public int PeersConnected { get; set; }

        /// <summary>
        /// How many peers we found out about from the tracker, or from pex,
        /// or from incoming connections, or from our resume file.
        /// </summary>
        [JsonProperty(PEERS_FROM)]
        public ITransmissionTorrentPeersFrom PeersFrom { get; set; }

        /// <summary>
        /// Number of peers that we're sending data to.
        /// </summary>
        [JsonProperty(PEERS_GETTING_FROM_US)]
        public int PeersGettingFromUs { get; set; }

        /// <summary>
        /// Number of peers that are sending data to us.
        /// </summary>
        [JsonProperty(PEERS_SENDING_TO_US)]
        public int PeersSendingToUs { get; set; }

        /// <summary>
        /// How much has been downloaded of the entire torrent.
        /// Range is [0..1]
        /// </summary>
        [JsonProperty(PERCENT_COMPLETE)]
        public double PercentComplete { get; set; }

        /// <summary>
        /// How much has been downloaded of the files the user wants. This differs
        /// from percentComplete if the user wants only some of the torrent's files.
        /// Range is [0..1]
        /// 
        /// See <seealso cref="LeftUntilDone"/>
        /// </summary>
        [JsonProperty(PERCENT_DONE)]
        public double PercentDone { get; set; }

        [JsonProperty(PIECES)]
        public string Pieces { get; set; }

        [JsonProperty(PIECE_COUNT)]
        public int PieceCount { get; set; }

        [JsonProperty(PIECE_SIZE)]
        public long PieceSize { get; set; }

        /// <summary>
        /// Array of <see langword="Priority"/>, with each one corresponding to a file.
        /// </summary>
        [JsonProperty(PRIORITIES)]
        public Priority[] Priorities { get; set; }

        /// <summary>
        /// Return the mime-type (e.g. "audio/x-flac") that matches more of the
        /// torrent's content than any other mime-type. 
        /// </summary>
        [JsonProperty(PRIMARY_MIME_TYPE)]
        public string PrimaryMimeType { get; set; }

        /// <summary>
        /// Download speed (B/s)
        /// </summary>
        [JsonProperty(RATE_DOWNLOAD)]
        public int RateDownload { get; set; }

        /// <summary>
        /// Upload speed (B/s)
        /// </summary>
        [JsonProperty(RATE_UPLOAD)]
        public int RateUpload { get; set; }

        /// <summary>
        /// When <see cref="Status"/> is <see cref="TorrentStatus.Verifying"/> or <see cref="TorrentStatus.VerifyQueue"/>,
        /// this is the percentage of how much of the files has been
        /// verified. When it gets to 1, the verify process is done.
        /// Range is [0..1]
        /// 
        /// See <seealso cref="Status"/>
        /// </summary>
        [JsonProperty(RECHECK_PROGRESS)]
        public double RecheckProgress { get; set; }

        /// <summary>
        /// Cumulative seconds the torrent's ever spent downloading 
        /// </summary>
        [JsonProperty(SECONDS_DOWNLOADING)]
        public int SecondsDownloading { get; set; }

        /// <summary>
        /// Cumulative seconds the torrent's ever spent seeding 
        /// </summary>
        [JsonProperty(SECONDS_SEEDING)]
        public int SecondsSeeding { get; set; }

        /// <summary>
        /// Byte count of all the piece data we'll have downloaded when we're done,
        /// whether or not we have it yet. This may be less than <see cref="TotalSize"/>
        /// if only some of the torrent's files are wanted.
        /// [0...<see cref="TotalSize"/>]
        /// </summary>
        [JsonProperty(SIZE_WHEN_DONE)]
        public long SizeWhenDone { get; set; }

        /// <summary>
        /// When the torrent was last started.
        /// </summary>
        [JsonProperty(START_DATE)]
        public long StartDate { get; set; }

        /// <summary>
        /// What is this torrent doing right now?
        /// </summary>
        [JsonProperty(STATUS)]
        public TorrentStatus Status { get; set; }

        [JsonProperty(TRACKERS)]
        public ITransmissionTorrentTracker[] Trackers { get; set; }

        [JsonProperty(TRACKER_STATS)]
        public ITransmissionTorrentTrackerStats[] TrackerStats { get; set; }

        /// <summary>
        /// Total size of the torrent, including unwanted files.
        /// </summary>
        [JsonProperty(TOTAL_SIZE)]
        public long TotalSize { get; set; }

        /// <summary>
        /// Path to the torrent file in the server
        /// </summary>
        [JsonProperty(TORRENT_FILE)]
        public string TorrentFile { get; set; }

        /// <summary>
        /// Byte count of all data you've ever uploaded for this torrent.
        /// </summary>
        [JsonProperty(UPLOADED_EVER)]
        public long UploadedEver { get; set; }

        /// <summary>
        /// Total uploaded bytes / total torrent size.
        /// </summary>
        [JsonProperty(UPLOAD_RATIO)]
        public double UploadRatio { get; set; }

        /// <summary>
        /// An array of booleans, with each item corresponding to a file
        /// </summary>
        [JsonProperty(WANTED)]
        public bool[] Wanted { get; set; }

        [JsonProperty(WEBSEEDS)]
        public string[] Webseeds { get; set; }

        /// <summary>
        /// Number of webseeds that are sending data to us.
        /// </summary>
        [JsonProperty(WEBSEEDS_SENDING_TO_US)]
        public int WebseedsSendingToUs { get; set; }
    }

    public interface ITransmissionTorrentFile
    {
        /// <summary>
        /// The current size of the file, i.e. how much we've downloaded
        /// </summary>
        [JsonProperty("bytesCompleted")]
        long BytesCompleted { get; set; }

        /// <summary>
        /// The total size of the file
        /// </summary>
        [JsonProperty("length")]
        long Length { get; set; }

        /// <summary>
        /// This file's name. Includes the full subpath in the torrent.
        /// </summary>
        [JsonProperty("name")]
        string Name { get; set; }
    }

    public interface ITransmissionTorrentFileStats
    {
        /// <summary>
        /// <inheritdoc cref="ITransmissionTorrentFile.BytesCompleted"/>
        /// </summary>
        [JsonProperty("bytesCompleted")]
        double BytesCompleted { get; set; }

        /// <summary>
        /// Do we want this file?
        /// </summary>
        [JsonProperty("wanted")]
        bool Wanted { get; set; }

        /// <summary>
        /// The file's priority
        /// </summary>
        [JsonProperty("priority")]
        Priority Priority { get; set; }
    }

    public interface ITransmissionTorrentPeers
    {
        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address")]
        string Address { get; set; }

        /// <summary>
        /// Client name
        /// </summary>
        [JsonProperty("clientName")]
        string ClientName { get; set; }

        /// <summary>
        /// Client is choked
        /// </summary>
        [JsonProperty("clientIsChoked")]
        bool ClientIsChoked { get; set; }

        /// <summary>
        /// Client is interested
        /// </summary>
        [JsonProperty("clientIsInterested")]
        bool ClientIsInterested { get; set; }

        /// <summary>
        /// Flag string
        /// </summary>
        [JsonProperty("flagStr")]
        string FlagStr { get; set; }

        /// <summary>
        /// Is downloading from
        /// </summary>
        [JsonProperty("isDownloadingFrom")]
        bool IsDownloadingFrom { get; set; }

        /// <summary>
        /// Is encrypted
        /// </summary>
        [JsonProperty("isEncrypted")]
        bool IsEncrypted { get; set; }

        /// <summary>
        /// Is uploading to
        /// </summary>
        [JsonProperty("isUploadingTo")]
        bool IsUploadingTo { get; set; }

        /// <summary>
        /// Is UTP
        /// </summary>
        [JsonProperty("isUTP")]
        bool IsUTP { get; set; }

        /// <summary>
        /// Peer is choked
        /// </summary>
        [JsonProperty("peerIsChoked")]
        bool PeerIsChoked { get; set; }

        /// <summary>
        /// Peer is interested
        /// </summary>
        [JsonProperty("peerIsInterested")]
        bool PeerIsInterested { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        [JsonProperty("port")]
        int Port { get; set; }

        /// <summary>
        /// Progress
        /// </summary>
        [JsonProperty("progress")]
        double Progress { get; set; }

        /// <summary>
        /// Rate to client
        /// </summary>
        [JsonProperty("rateToClient")]
        int RateToClient { get; set; }

        /// <summary>
        /// Rate to peer
        /// </summary>
        [JsonProperty("rateToPeer")]
        int RateToPeer { get; set; }
    }

    /// <summary>
    /// Torrent peers from
    /// </summary>
    public interface ITransmissionTorrentPeersFrom
    {
        /// <summary>
        /// From DHT
        /// </summary>
        [JsonProperty("fromDht")]
        int FromDHT { get; set; }

        /// <summary>
        /// From incoming
        /// </summary>
        [JsonProperty("fromIncoming")]
        int FromIncoming { get; set; }

        /// <summary>
        /// From LPD
        /// </summary>
        [JsonProperty("fromLpd")]
        int FromLPD { get; set; }

        /// <summary>
        /// From LTEP
        /// </summary>
        [JsonProperty("fromLtep")]
        int FromLTEP { get; set; }

        /// <summary>
        /// From PEX
        /// </summary>
        [JsonProperty("fromPex")]
        int FromPEX { get; set; }

        /// <summary>
        /// From tracker
        /// </summary>
        [JsonProperty("fromTracker")]
        int FromTracker { get; set; }
    }

    /// <summary>
    /// Contains arrays of torrents and removed torrents
    /// </summary>
    public interface ITransmissionTorrents
    {
        /// <summary>
        /// Array of torrents
        /// </summary>
        [JsonProperty("torrents")]
        TorrentInfo[] Torrents { get; set; }

        /// <summary>
        /// Array of torrent-id numbers of recently-removed torrents
        /// </summary>
        [JsonProperty("removed")]
        TorrentInfo[] Removed { get; set; }
    }

    public enum TorrentError
    {
        /// <summary>
        /// Everything's fine
        /// </summary>
        Ok = 0,
        /// <summary>
        /// When we anounced to the tracker, we got a warning in the response
        /// </summary>
        TrackerWarning = 1,
        /// <summary>
        /// When we anounced to the tracker, we got an error in the response
        /// </summary>
        TrackerError = 2,
        /// <summary>
        /// Local trouble, such as disk full or permissions error
        /// </summary>
        LocalError = 3
    }

    public enum TorrentStatus
    {
        /// <summary>
        /// Torrent is stopped
        /// </summary>
        Stopped = 0,

        /// <summary>
        /// Torrent is queued to verify local data
        /// </summary>
        VerifyQueue = 1,

        /// <summary>
        /// Torrent is verifying local data
        /// </summary>
        Verifying = 2,

        /// <summary>
        /// Torrent is queued to download
        /// </summary>
        DownloadQueue = 3,

        /// <summary>
        /// Torrent is downloading
        /// </summary>
        Downloading = 4,

        /// <summary>
        /// Torrent is queued to seed
        /// </summary>
        QueueSeed = 5,

        /// <summary>
        /// Torrent is seeding
        /// </summary>
        Seeding = 6,
    }
}
