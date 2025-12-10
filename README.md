## What does this tool do

- Sends a request to fedora mirror manager, typically something like `https://mirrors.fedoraproject.org/metalink?repo=fedora-37&arch=x86_64`; release number (`37`) and architecture (`x86_64`) can be given as input values

- Parse the XML, processing `url` entities
- Process each URL and remove anything after `/x86_64`
- Uses the remaining part of the URL as the base pattern for a regular expression to be then used in squid, to cache `.rmp` files irrespective of the mirror. 

> Currently, I'm doing something strange, possibly an oversight: I first trim the URL at `/x86_64` (i.e. remove everything after that, inclusive), then `/x86_64` is added in the regular expression. But may be just because it's simpler to create the regular expression, because now `x86_64` in part of a group.

## Improvements

Add support for
- ✅ ~~fedora-updates (https://mirrors.fedoraproject.org/metalink?repo=updates-released-f37&arch=x86_64)~~
- ✅ ~~rpmfusion-free (https://mirrors.rpmfusion.org/metalink?repo=free-fedora-37&arch=x86_64)~~
- ✅ ~~rpmfusion-free-updates (https://mirrors.rpmfusion.org/metalink?repo=free-fedora-updates-released-37&arch=x86_64)~~
- ✅ ~~rpmfusion-nonfree (https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-37&arch=x86_64)~~
- ✅ ~~rpmfusion-nonfree-updates (https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-updates-released-37&arch=x86_64)~~

## Important notes

> Starting with Squid-3.5 additional parameters passed to the helper which may be configured with [url_rewrite_extras](http://www.squid-cache.org/Doc/config/url_rewrite_extras). For backward compatibility the default key-extras for URL helpers matches the format fields sent by Squid-3.4 and older in this field position:

  ```bash
  ip/fqdn ident method [urlgroup] kv-pair
  ```  
Actual sample from Squid `cache.log` (after enabling `debug_options` in `/etc/squid/squid.conf` with `debug_options 84,9`)

```console
2023/05/21 18:00:10.439 kid1| 84,9| helper.cc(556) submit:  buf[184]=http://dl.fedoraproject.org/pub/fedora/linux/releases/37/Everything/x86_64/os/Packages/e/eclib-20220621-3.fc37.x86_64.rpm 192.168.0.51/192.168.0.51 - GET myip=192.168.0.22 myport=3128
```

## References

- [Feature: Store ID](https://wiki.squid-cache.org/Features/StoreID)
- [StoreID database](https://wiki.squid-cache.org/Features/StoreID/DB)
- [Infrastructure/MirrorManager](https://www.fedoraproject.org/wiki/Infrastructure/MirrorManager)
- [Metalink format mirrorlist](https://www.fedoraproject.org/wiki/Infrastructure/MirrorManager#Metalink_format_mirrorlist)
- https://github.com/sinner-/kickstart-fedora-workstation/blob/master/workstation.ks