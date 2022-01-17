# This is my fork of Project Lighthouse
I made a few minor changes to the website to include the link to this fork, aswell as credits of the Project Lighthouse Team. and mention of Admins of this instance, so you can have an account made for you, which is needed to connect to the server, 403 error is normal first time, check the authentication page on the website http://fridinator.fo:10060 if your Public IP is shown as an authentication attempt, whitelist it by accepting the request, then restart your game, and it should connect correctly.

Are you looking for the patched version of RPCS3? I have a fork that includes binaries, so you don't have to compile it yourself https://github.com/FridiNaTor1/rpcs3

Remember you need to patch your eboot either with an Hex editor, or by using UnionPatcher(https://github.com/LBPUnion/UnionPatcher/), which is the perferred option for starters. If you play on real hardware, or you want to just be able to play the game on RPCS3 by double clicking it, you will also need a resigner, like trueancestor.

The rest of this except the mention of jvyden fork of RPCS3 which is removed because it maybe confusing if there are two forks in this readme. And the change to localhost into fridinator.fo , will be straight from the original Project Lighthouse, as it gives you information about the project, aswell as a small tutorial of UnionPatcher, and the compatibility list. It will also give you a link to their Discord, which will have some people that could help you. We have a Discord server now that you can contact admins, and talk to other people in the server. Right now the Official Instance from LBPUnion is fully private atm, but mine you can get access too, you just need an admin to make you an account.
You can join our Discord here https://discord.gg/qdGQbT8TaU
# Project Lighthouse

Project Lighthouse is a clean-room, open-source custom server for LittleBigPlanet. This is a project conducted by the [LBP Union Ministry of Technology Research and Development team.](https://www.lbpunion.com/technology) For concerns and inquiries about the project, please [contact us here.](https://www.lbpunion.com/contact) For general questions and discussion about Project Lighthouse, please see the [megathread](https://www.lbpunion.com/forum/union-hall/project-lighthouse-littlebigplanet-private-servers-megathread) on our forum. 

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

Start by getting a copy of LittleBigPlanet 2 installed. It can be digital (NPUA80662) or disc (BCUS98245). For those
that don't, the [RPCS3 Quickstart Guide](https://rpcs3.net/quickstart) should cover it.

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

Finally, take a break. Chances are that took a while.

## Contributing Tips

### Database migrations

Some modifications may require updates to the database schema. You can automatically create a migration file by:

1. Making sure the tools are installed. You can do this by running `dotnet tool restore`.
2. Making sure `LIGHTHOUSE_DB_CONNECTION_STRING` is set correctly. See the `Running` section for more details.
3. Modifying the database schema via the C# portion of the code. Do not modify the actual SQL database.
4. Running `dotnet ef migrations add <NameOfMigrationInPascalCase> --project ProjectLighthouse`.

This process will create a migration file from the changes made in the C# code.

The new migrations will automatically be applied upon starting Lighthouse.

### Running tests

You can run tests either through your IDE or by running `dotnet tests`.

Keep in mind while running database tests you need to have `LIGHTHOUSE_DB_CONNECTION_STRING` set.

### Continuous Integration (CI) Tips

- You can skip CI runs for a commit if you specify `[skip ci]` at the beginning of the commit name. This is useful for
  formatting changes, etc.
- When creating your first pull request, CI will not run initially. A team member will have to approve you for use of
  running CI on a pull request. This is because of GitHub policy.

## Compatibility across games and platforms

| Game     | Console (PS3/Vita/PSP)                | Emulator (RPCS3/Vita3k/PPSSPP)                           | Next-Gen (PS4/PS5/Vita) |
|----------|---------------------------------------|----------------------------------------------------------|-------------------------|
| LBP1     | Compatible                            | Incompatible, crashes on entering pod computer           | N/A                     |
| LBP2     | Compatible                            | Compatible with patched RPCS3                            | N/A                     |
| LBP3     | Somewhat compatible, frequent crashes | Somewhat compatible with patched RPCS3, frequent crashes | Incompatible            |
| LBP Vita | Compatible                            | Incompatible, marked as "bootable" on Vita3k             | N/A                     |
| LBP PSP  | Potentially compatible                | Incompatible, PSN not supported on PPSSPP                | Potentially Compatible  |

While LBP Vita and LBP PSP can be supported, they are not properly seperated from the mainline games at this time. We
recommend you run seperate instances for these games to avoid problems.

Project Lighthouse is still a heavy work in progress, so this chart is subject to change at any point.
