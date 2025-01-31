#Some assets are owned by SIE

#Donation
Server is expensive for me to keep up, so if you want to, you can donate for server upkeep. If donations are high enough, I could even upgrade the server in the future
Current price of the server monthly is $104.89 USD you can support the server in two ways.

1. MCProhosting. My server is running through MCProhosting dedicated Linux computers. If you already are looking into getting a server of your own, like a Minecraft server. Then it would help a lot if you do so after using my affiliate link, it doesn't cost you extra, but it will act as a discount for my server. https://mcprohosting.com/order?aff=418

2. PayPal. You can also directly use PayPal to donate, you can find me via @FridiNaTor or this link https://paypal.me/FridiNaTor?country.x=DK&locale.x=en_US

Remember that this is just OPTIONAL no requirement to play!

# This is my fork of Project Lighthouse
I made a few minor changes to the website to include the link to this fork, aswell as credits of the Project Lighthouse Team. and mention of Admins of this instance, so you can have an account made for you, which is needed to connect to the server, 403 error is normal first time, check the authentication page on the website http://fridinator.fo:10060 if your Public IP is shown as an authentication attempt, whitelist it by accepting the request, then restart your game, and it should connect correctly.

Are you looking for the patched version of RPCS3? I have a fork that includes binaries, so you don't have to compile it yourself https://github.com/FridiNaTor1/rpcs3

Remember you need to patch your eboot either with an Hex editor, or by using [UnionPatcher,](https://github.com/LBPUnion/UnionPatcher/) which is the perferred option for starters. If you play on real hardware, or you want to just be able to play the game on RPCS3 by double clicking it, you will also need a resigner, like trueancestor.

The rest of this except the mention of jvyden fork of RPCS3 which is removed because it maybe confusing if there are two forks in this readme. And the change to localhost into fridinator.fo , will be straight from the original Project Lighthouse, as it gives you information about the project, aswell as a small tutorial of UnionPatcher, and the compatibility list. It will also give you a link to their Discord, which will have some people that could help you. We have a Discord server now that you can contact admins, and talk to other people in the server. Right now the Official Instance from LBPUnion is fully private atm, but mine you can get access too, you just need an admin to make you an account.
You can join our Discord here https://discord.gg/qdGQbT8TaU
# Project Lighthouse

Project Lighthouse is a clean-room, open-source custom server for LittleBigPlanet. This is a project conducted by
the [LBP Union Ministry of Technology Research and Development team.](https://www.lbpunion.com/technology) For concerns
and inquiries about the project, please [contact us here.](https://www.lbpunion.com/contact) For general questions and
discussion about Project Lighthouse, please see
the [megathread](https://www.lbpunion.com/forum/union-hall/project-lighthouse-littlebigplanet-private-servers-megathread)
on our forum.

## WARNING!

This is **beta software**, and thus is **not stable**.

We're not responsible if someone hacks your machine and wipes your database.

Make frequent backups, and be sure to report any vulnerabilities.

## Building

This will be written when we're out of beta. Consider this your barrier to entry ;).

It is recommended to build with Release if you plan to use Lighthouse in a production environment.

## Running

Lighthouse requires a MySQL database at this time. For Linux users running docker, one can be set up using
the `docker-compose.yml` file in the root of the project folder.

Next, make sure the `LIGHTHOUSE_DB_CONNECTION_STRING` environment variable is set correctly. By default, it
is `server=127.0.0.1;uid=root;pwd=lighthouse;database=lighthouse`. If you are running the database via the
above `docker-compose.yml` you shouldn't need to change this. For other development/especially production environments
you will need to change this.

Once you've gotten MySQL running you can run Lighthouse. It will take care of the rest.

## Connecting

PS3 is difficult to set up, so I will be going over how to set up RPCS3 instead. A guide will be coming for PS3 closer
to release. You can also follow this guide if you want to learn how to modify your EBOOT.

There are also community-provided guides in [the official LBP Union Discord](https://www.lbpunion.com/discord), which
you can follow at your own discretion.

Start by getting a copy of LittleBigPlanet 1/2 installed. (Check the LittleBigPlanet 1 section, since you'll need to do
extra steps for your game to not crash upon entering pod computer). It can be digital (NPUA80472/NPUA80662) or disc (
BCUS98148/BCUS98245). For those that don't, the [RPCS3 Quickstart Guide](https://rpcs3.net/quickstart) should cover it.

Next, download [UnionPatcher](https://github.com/LBPUnion/UnionPatcher/). Binaries can be found by reading the README.md
file.

You should have everything you need now, so open up RPCS3 and go to Utilities -> Decrypt PS3 Binaries. Point this
to `rpcs3/dev_hdd0/game/(title id)/USRDIR/EBOOT.BIN`. You can grab your title id by right clicking the game in RPCS3 and
clicking Copy Info -> Copy Serial.

This should give you a file named `EBOOT.elf` in the same folder. Next, fire up UnionPatcher (making sure to select the
correct project to start, e.g. on Mac launch `UnionPatcher.Gui.MacOS`.)

Now that you have your decrypted eboot, open UnionPatcher and select the `EBOOT.elf` you got earlier in the top box,
enter `http://fridinator.fo:10060/LITTLEBIGPLANETPS3_XML` in the second, and the output filename in the third. For this
guide I'll use `EBOOTlocalhost.elf`.

Now, copy the `EBOOTlocalhost.elf` file to where you got your `EBOOT.elf` file from, and you're now good to go.

To launch the game with the patched EBOOT, open up RPCS3, go to File, Boot SELF/ELF, and open up `EBOOTlocalhost.elf`.

Assuming you are running the patched version of RPCS3, you patched the file correctly, the database is migrated, and
Lighthouse is running, the game should now connect.

### LittleBigPlanet 1

For LittleBigPlanet 1 to work with RPCS3, follow the steps for LittleBigPlanet 2.

First, open your favourite hex editor. We recommend [HxD](https://mh-nexus.de/en/hxd/).

Once you have a hex editor open, open your `EBOOTlocalhost.elf` file and search for the hex
values `73 63 65 4E 70 43 6F 6D 6D 65 72 63 65 32`. In HxD, this would be done by clicking on Search -> Replace,
clicking on the `Hex-values` tab, and entering the hex there.

Then, you can zero it out by replacing it with `00 00 00 00 00 00 00 00 00 00 00 00 00 00`.

What this does is remove all the references to the sceNpCommerce2 function. The function is used for purchasing DLC,
which is impossible on Lighthouse. The reason why it must be patched out is because RPCS3 doesn't support the function
at this moment.

Then save the file, and your LBP1 EBOOT can now be used with RPCS3.

Finally, take a break. Chances are that took a while.

## DISCLAIMER

This is **beta software**, and thus is **not stable nor is it secure**.

While Project Lighthouse is in a mostly working state, **we ask that our software not be used in a production
environment until release**.

This is because we have not entirely nailed security down yet, and **your instance WILL get attacked** as a result. It's
happened before, and it'll happen again.

Simply put, **Project Lighthouse is not ready for the general public yet**.

In addition, we're not responsible if someone hacks your machine and wipes your database, so make frequent backups, and
be sure to report any vulnerabilities. Thank you in advance.

## Building

This will be written when we're out of beta. Consider this your barrier to entry ;).

It is recommended to build with `Release` if you plan to use Lighthouse in a production environment.

## Contributing

Please see `CONTRIBUTING.md` for more information.

## Compatibility across games and platforms

| Game     | Console (PS3/Vita/PSP)              | Emulator (RPCS3/Vita3k/PPSSPP)                                        | Next-Gen (PS4/PS5/Vita) |
|----------|-------------------------------------|-----------------------------------------------------------------------|-------------------------|
| LBP1     | Compatible                          | Compatible with patched RPCS3 and sceNpCommerce2 patched out of EBOOT | N/A                     |
| LBP2     | Compatible                          | Compatible with patched RPCS3                                         | N/A                     |
| LBP3     | Mostly compatible, frequent crashes | Mostly compatible with patched RPCS3, frequent crashes                | Incompatible            |
| LBP Vita | Compatible                          | Incompatible, marked as "Intro" on Vita3k                             | N/A                     |
| LBP PSP  | Potentially compatible              | Incompatible, PSN not supported on PPSSPP                             | Potentially Compatible  |

While LBP Vita and LBP PSP can be supported, they are not properly seperated from the mainline games at this time. We
recommend you run separate instances for these games to avoid problems.

Project Lighthouse is still a heavy work in progress, so this chart is subject to change at any point.
