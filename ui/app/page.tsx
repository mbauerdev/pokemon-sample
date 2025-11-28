"use client";

import { RelayEnvironmentProvider } from "react-relay";
import environment from "@/client/network";

import dynamic from "next/dynamic";
import { Suspense } from "react";
import { PokemonList } from "@/components";

function PokemonApp() {
  return (
    <RelayEnvironmentProvider environment={environment}>
      <Suspense fallback={<div>Loading...</div>}>
        <PokemonList />
      </Suspense>
    </RelayEnvironmentProvider>
  );
}

// Disable SSR for the Relay component
const PokemonAppNoSSR = dynamic(() => Promise.resolve(PokemonApp), {
  ssr: false,
});

export default function Home() {
  return <PokemonAppNoSSR />;
}
