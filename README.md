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