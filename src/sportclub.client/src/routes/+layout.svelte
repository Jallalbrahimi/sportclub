<script lang="ts">
	import '../app.css';

	let { children } = $props();
</script>

<!-- NAVBAR -->
<div class="navbar bg-base-100 shadow-sm">
	<!-- HOME BUTTON -->
	<div class="flex-1">
		<a class="btn btn-ghost text-xl" href="/">SportClub</a>
	</div>

	<!-- NAVIGATION -->
	<div class="navbar-center"></div>

	<div class="navbar-end">
		<!-- INDICATOR -->
		<button class="btn btn-ghost btn-circle" aria-label="Notifications">
			<div class="indicator">
				<svg
					xmlns="http://www.w3.org/2000/svg"
					class="h-5 w-5"
					fill="none"
					viewBox="0 0 24 24"
					stroke="currentColor"
				>
					<path
						stroke-linecap="round"
						stroke-linejoin="round"
						stroke-width="2"
						d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
					/>
				</svg>
				<span class="badge badge-xs badge-primary indicator-item"></span>
			</div>
		</button>

		<!-- USER MENU -->
		<div class="dropdown dropdown-end">
			<div tabindex="0" role="button" class="btn btn-ghost btn-circle avatar">
				<div class="w-10 rounded-full">
					<img
						alt="Tailwind CSS Navbar component"
						src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
					/>
				</div>
			</div>
			<ul
				tabindex="-1"
				class="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
			>
				<li>
					<a href="/" class="justify-between">
						Profile
						<span class="badge">New</span>
					</a>
				</li>
				<li><a href="/">Settings</a></li>
				<li><a href="/">Logout</a></li>
			</ul>
		</div>
	</div>
</div>

<div class="layout">
	<main>
		{@render children()}
	</main>

	<aside>
		<h2>More posts</h2>
		<ul></ul>
	</aside>
</div>

<style>
</style>
