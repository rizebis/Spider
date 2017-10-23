
using System;
using System.Collections.Generic;
using System.Text;
using DotnetSpider.Core;
using DotnetSpider.Core.Downloader;
using DotnetSpider.Core.Scheduler;

namespace Spider
{
    /// <summary>
    /// 小说爬虫
    /// </summary>
    public class NovelSpider
    {
        public void Start()
        {
            var site = new Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            site.AddStartUrl("http://www.biqiuge.com/");
            var spider = DotnetSpider.Core.Spider.Create(site,
                                                        new QueueDuplicateRemovedScheduler(),
                                                        new NovelPageProcessor())
                                                        .AddPipeline(new NovelPipeline());
            spider.Downloader = new HttpClientDownloader();
            spider.ThreadNum = 1;
            spider.EmptySleepTime = 3000;

            spider.Run();
        }
    }
}
